namespace Python.Runtime.Native {
    using System;
    using AdvancedDLSupport;

    public class AdvancedDLReferenceCounting : IPythonReferenceCounting
    {
        static readonly IUnsafePythonReferenceCounting Unsafe =
            new NativeLibraryBuilder(ImplementationOptions.UseIndirectCalls)
            .ActivateInterface<IUnsafePythonReferenceCounting>(
                @"C:\Program Files (x86)\Microsoft Visual Studio\Shared\Python36_64\python36.dll");

        public void Py_IncRef(Borrowed<PyObject> pyObject) =>
            Unsafe.Py_IncRef(pyObject.DangerousGetHandle());
        public void Py_DecRef(Borrowed<PyObject> pyObject) =>
            Unsafe.Py_DecRef(pyObject.DangerousGetHandle());
    }

    public interface IUnsafePythonReferenceCounting {
        void Py_IncRef(IntPtr pyObject);
        void Py_DecRef(IntPtr pyObject);
    }
}
