namespace Python.Runtime.Native {
    public interface IPythonModuleImporting {
        Owned<PyObject> PyImport_ImportModule(string name);
        Borrowed<PyObject> PyImport_GetModuleDict();
    }
}
