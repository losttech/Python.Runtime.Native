namespace Python.Runtime.Native {
    public interface IPythonReferenceCounting {
        void Py_IncRef(Borrowed<PyObject> pyObject);
        void Py_DecRef(Borrowed<PyObject> pyObject);
    }
}
