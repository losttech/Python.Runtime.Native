namespace Python.Runtime.Native {
    using System;
    using System.Runtime.InteropServices;

    public sealed class PInvokeReferenceCounting: IPythonReferenceCounting
    {
        public void Py_IncRef(Borrowed<PyObject> pyObject) => NativeMethods.Py_IncRef(pyObject.DangerousGetHandle());
        public void Py_DecRef(Borrowed<PyObject> pyObject) => NativeMethods.Py_DecRef(pyObject.DangerousGetHandle());

        static class NativeMethods
        {
            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Py_IncRef(IntPtr pyObject);
            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Py_DecRef(IntPtr pyObject);
        }
    }
}
