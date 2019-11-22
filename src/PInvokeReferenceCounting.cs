namespace Python.Runtime.Native {
    using System.Runtime.InteropServices;

    public sealed class PInvokeReferenceCounting: IPythonReferenceCounting
    {
        public void Py_IncRef(Borrowed<PyObject> pyObject) => NativeMethods.Py_IncRef(pyObject);
        public void Py_DecRef(Borrowed<PyObject> pyObject) => NativeMethods.Py_DecRef(pyObject);

        static class NativeMethods
        {
            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Py_IncRef(Borrowed<PyObject> pyObject);
            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Py_DecRef(Borrowed<PyObject> pyObject);
        }
    }
}
