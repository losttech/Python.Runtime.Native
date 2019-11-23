namespace Python.Runtime.Native {
    using System;
    class SafeReferenceCountingWrapper: IPythonReferenceCounting {
        readonly IUnsafePythonReferenceCounting @unsafe;
        public SafeReferenceCountingWrapper(IUnsafePythonReferenceCounting @unsafe) {
            this.@unsafe = @unsafe ?? throw new ArgumentNullException(nameof(@unsafe));
        }

        public void Py_IncRef(Borrowed<PyObject> pyObject) =>
            this.@unsafe.Py_IncRef(pyObject.DangerousGetHandle());
        public void Py_DecRef(Borrowed<PyObject> pyObject) =>
            this.@unsafe.Py_DecRef(pyObject.DangerousGetHandle());
    }
}
