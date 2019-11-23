namespace Python.Runtime.Native {
    using System;
    using AdvancedDLSupport;

    public static class AdvancedDLReferenceCounting
    {
        public static readonly IUnsafePythonReferenceCounting Unsafe =
            new NativeLibraryBuilder(ImplementationOptions.UseIndirectCalls)
            .ActivateInterface<IUnsafePythonReferenceCounting>(
                @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64\python36.dll");
    }
}
