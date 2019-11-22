namespace Python.Runtime.Native {
    public interface IPythonInitialization
    {
        void Py_Initialize();
        void Py_InitializeEx(bool initSignalHandlers);
        bool Py_IsInitialized();
        void Py_Finalize();
    }
}
