namespace Python.Runtime.Native {
    using System;
    using System.Runtime.InteropServices;

    [System.Security.SecurityCritical]
    public sealed class PythonObjectHandle: CriticalHandle
    {
        public PythonObjectHandle() : base(IntPtr.Zero) { }

        protected override bool ReleaseHandle() {
            PythonCApi.Py_DecRef(this.Borrow());
            return true;
        }

        public override bool IsInvalid => this.handle == IntPtr.Zero;

        public BorrowedObject Borrow()
            => this.IsInvalid
                ? throw new ObjectDisposedException(nameof(PythonObjectHandle))
                : new BorrowedObject(this.handle);
    }
}
