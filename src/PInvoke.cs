﻿namespace Python.Runtime.Native {
    using System.Runtime.InteropServices;

    public sealed class PInvoke : IPythonInitialization, IPythonModuleImporting
    {
        public void Py_Finalize() => NativeMethods.Py_Finalize();
        public void Py_Initialize() => NativeMethods.Py_Initialize();
        public void Py_InitializeEx(bool initSignalHandlers) => throw new System.NotImplementedException();
        public bool Py_IsInitialized() => throw new System.NotImplementedException();

        public Borrowed<PyObject> PyImport_GetModuleDict() => NativeMethods.PyImport_GetModuleDict();

        public Owned<PyObject> PyImport_ImportModule(string name) => NativeMethods.PyImport_ImportModule(name);

        static class NativeMethods {
            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Py_Finalize();
            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern void Py_Initialize();

            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern Borrowed<PyObject> PyImport_GetModuleDict();

            [DllImport(Py.Dll, CallingConvention = CallingConvention.Cdecl)]
            public static extern Owned<PyObject> PyImport_ImportModule(string name);
        }
    }
}