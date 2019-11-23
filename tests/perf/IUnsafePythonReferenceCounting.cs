namespace Python.Runtime.Native {
    using System;
    public interface IUnsafePythonReferenceCounting {
        void Py_IncRef(IntPtr pyObject);
        void Py_DecRef(IntPtr pyObject);
    }
}