namespace Python.Runtime.Native {
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;
    using System.Security;
    using NativeLibraryLoader;

    public sealed class MarshalReferenceCounting : IPythonReferenceCounting {
        public void Py_IncRef(Borrowed<PyObject> pyObject) => IncRef.Invoke(pyObject.DangerousGetHandle());
        public void Py_DecRef(Borrowed<PyObject> pyObject) => DecRef.Invoke(pyObject.DangerousGetHandle());

        static readonly NativeLibrary Python = new NativeLibrary(Py.Dll);
        static readonly PyObjectOp IncRef = Python.LoadFunction<PyObjectOp>("Py_IncRef");
        static readonly PyObjectOp DecRef = Python.LoadFunction<PyObjectOp>("Py_DecRef");

        [UnmanagedFunctionPointer(CallingConvention.Cdecl)]
        [SuppressUnmanagedCodeSecurity]
        delegate void PyObjectOp(IntPtr pyObject);

        static IntPtr Check(IntPtr win32Result) {
            if (win32Result == IntPtr.Zero)
                throw new Win32Exception();
            return win32Result;
        }
    }
}
