namespace Python.Runtime.Native {
    using System.Runtime.InteropServices;

    public static class EmitBinderReferenceCounting
    {
        public static readonly IUnsafePythonReferenceCounting Unsafe =
            EmitBinder.Bind<IUnsafePythonReferenceCounting>(
                @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64\python36.dll",
                CallingConvention.Cdecl);
    }
}
