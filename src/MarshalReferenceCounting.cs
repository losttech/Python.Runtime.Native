namespace Python.Runtime.Native {
    using System;
    using System.ComponentModel;
    using System.Runtime.InteropServices;

    public sealed class MarshalReferenceCounting : IPythonReferenceCounting {
        public void Py_IncRef(Borrowed<PyObject> pyObject) => IncRef.Invoke(pyObject.DangerousGetHandle());
        public void Py_DecRef(Borrowed<PyObject> pyObject) => DecRef.Invoke(pyObject.DangerousGetHandle());

        static readonly PyObjectOp IncRef;
        static readonly PyObjectOp DecRef;

        delegate void PyObjectOp(IntPtr pyObject);

        static MarshalReferenceCounting() {
            var python = Check(NativeMethods.LoadLibrary(Py.Dll + ".dll"));
            IncRef = Marshal.GetDelegateForFunctionPointer<PyObjectOp>(
                Check(NativeMethods.GetProcAddress(python, "Py_IncRef")));
            DecRef = Marshal.GetDelegateForFunctionPointer<PyObjectOp>(
                Check(NativeMethods.GetProcAddress(python, "Py_DecRef")));
        }

        static IntPtr Check(IntPtr win32Result) {
            if (win32Result == IntPtr.Zero)
                throw new Win32Exception();
            return win32Result;
        }

        static class NativeMethods
        {
            [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr LoadLibrary(string fileName);

            [DllImport("kernel32", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
            public static extern IntPtr GetProcAddress(IntPtr library, string symbol);
        }
    }
}
