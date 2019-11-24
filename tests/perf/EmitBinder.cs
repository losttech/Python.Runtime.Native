namespace Python.Runtime.Native {
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Reflection.Emit;
    using System.Runtime.InteropServices;
    using System.Threading;

    public static class EmitBinder
    {
        static int implementationIndex;

        static readonly ConstructorInfo DllImportCtor = typeof(DllImportAttribute)
            .GetConstructor(new []{typeof(string)});
        static readonly FieldInfo CallingConventionField = typeof(DllImportAttribute)
            .GetField(nameof(DllImportAttribute.CallingConvention));
        public static T Bind<T>(string libraryPath, CallingConvention callingConvention) {
            if (!typeof(T).IsInterface)
                throw new ArgumentException("Type parameter must be an interface", paramName: nameof(T));

            string suffix = Interlocked.Increment(ref implementationIndex).ToString(CultureInfo.InvariantCulture);
            var assemblyName = new AssemblyName(typeof(T).Name + "." + Path.GetFileName(libraryPath) + suffix);
            var assembly = AssemblyBuilder.DefineDynamicAssembly(assemblyName, AssemblyBuilderAccess.Run);

            var module = assembly.DefineDynamicModule(typeof(T).Name);

            var implementationBuilder = module.DefineType(
                name: "ImplFor" + typeof(T).Name,
                TypeAttributes.NotPublic | TypeAttributes.UnicodeClass);
            implementationBuilder.AddInterfaceImplementation(typeof(T));
            foreach (var methodInfo in typeof(T).GetMethods()) {
                var parameters = methodInfo.GetParameters();

                var pinvoke = implementationBuilder.DefinePInvokeMethod(
                    name: methodInfo.Name,
                    dllName: libraryPath,
                    MethodAttributes.Static | MethodAttributes.PinvokeImpl,
                    CallingConventions.Standard,
                    methodInfo.ReturnType,
                    parameters.Select(p => p.ParameterType).ToArray(),
                    callingConvention,
                    CharSet.Auto);
                pinvoke.SetImplementationFlags(pinvoke.GetMethodImplementationFlags() | MethodImplAttributes.PreserveSig);

                var wrapper = implementationBuilder.DefineMethod(methodInfo.Name,
                    MethodAttributes.Public | MethodAttributes.Virtual,
                    methodInfo.ReturnType,
                    parameters.Select(p => p.ParameterType).ToArray());
                var il = wrapper.GetILGenerator();

                for (short index = 1; index <= parameters.Length; index = checked((short)(index + 1))) {
                    il.Emit(OpCodes.Ldarg_S, index);
                }
                il.EmitCall(OpCodes.Call, pinvoke, Array.Empty<Type>());
                il.Emit(OpCodes.Ret);
            }

            var implementation = implementationBuilder.CreateTypeInfo();
            return (T)Activator.CreateInstance(implementation);
        }
    }
}
