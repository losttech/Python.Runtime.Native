namespace Python.Runtime.Native {
    using System;
    using System.Runtime.InteropServices;

    [System.Security.SecurityCritical]
    public sealed class PythonInterpreterHandle: CriticalHandle {
        public PythonInterpreterHandle() : base(IntPtr.Zero) { }

        protected override bool ReleaseHandle() {
            PythonCApi.Py_EndInterpreter(this);
            return true;
        }

        public override bool IsInvalid => this.handle == IntPtr.Zero;
    }
}
