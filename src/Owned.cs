namespace Python.Runtime.Native {
    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [SuppressMessage("Design",
        "CA1066:Type {0} should implement IEquatable<T> because it overrides Equals",
        Justification = "ref structs can not implement interfaces, as they are not boxable")]
    public ref struct Owned<T> {
        readonly IntPtr handle;

        public Owned(IntPtr handle) {
            if (handle == IntPtr.Zero) throw new ArgumentNullException(nameof(handle));
            this.handle = handle;
        }
        [Pure]
        public bool Equals(Owned<T> other) => this.handle == other.handle;
        [Pure]
        public override int GetHashCode() => this.handle.GetHashCode();
        [Pure]
        public static bool operator ==(Owned<T> left, Owned<T> right)
            => left.Equals(right);
        [Pure]
        public static bool operator !=(Owned<T> left, Owned<T> right)
            => !(left == right);

        // ref struct can never be boxed, so it is impossible to call this via base class (object)
#pragma warning disable CS0809 // Obsolete member overrides non-obsolete member
        [Obsolete(message: "This method should never be called, as ref struct can not be boxed", error: true)]
        [SuppressMessage(category: "Design",
            checkId: "CA1065:Do not raise exceptions in unexpected locations",
            Justification = "This method should never be called, which is indicated by Obsolete attribute")]
        public override bool Equals(object obj) => throw new InvalidOperationException();
#pragma warning restore CS0809 // Obsolete member overrides non-obsolete member
    }
}
