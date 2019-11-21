namespace Python.Runtime.Native {
    using System;

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
        "CA1066:Type {0} should implement IEquatable<T> because it overrides Equals",
        Justification = "ref structs can not implement interfaces, as they are not boxable")]
    public ref struct BorrowedObject
    {
        readonly IntPtr handle;

        public BorrowedObject(IntPtr handle) {
            if (handle == IntPtr.Zero) throw new ArgumentNullException(nameof(handle));
            this.handle = handle;
        }

        public bool Equals(BorrowedObject other) => this.handle == other.handle;
        public override bool Equals(object obj) => false;

        public override int GetHashCode() => this.handle.GetHashCode();

        public static bool operator ==(BorrowedObject left, BorrowedObject right)
            => left.Equals(right);

        public static bool operator !=(BorrowedObject left, BorrowedObject right)
            => !(left == right);
    }
}
