namespace Python.Runtime.Native {
    using System;
    using BenchmarkDotNet.Attributes;
    using BenchmarkDotNet.Jobs;

    [SimpleJob(RuntimeMoniker.CoreRt30)]
    [SimpleJob(RuntimeMoniker.Net48)]
    [SimpleJob(RuntimeMoniker.Mono)]
    [SimpleJob(RuntimeMoniker.NetCoreApp30)]
    public class ReferenceCountingBenchmark: IDisposable {
        readonly IntPtr testObject;
        readonly PInvoke python = new PInvoke();

        [Benchmark(Baseline = true)]
        public void RefCounting_PInvoke() {
            this.RefCounting(new Borrowed<PyObject>(this.testObject), new PInvokeReferenceCounting());
        }

        [Benchmark]
        public void RefCounting_Marshal() {
            this.RefCounting(new Borrowed<PyObject>(this.testObject), new MarshalReferenceCounting());
        }

        [Benchmark]
        public void RefCounting_Calli() {
            this.RefCounting(new Borrowed<PyObject>(this.testObject),
                new SafeReferenceCountingWrapper(AdvancedDLReferenceCounting.Unsafe));
        }

        [Benchmark]
        public void RefCounting_EmitBinder() {
            this.RefCounting(new Borrowed<PyObject>(this.testObject),
                new SafeReferenceCountingWrapper(EmitBinderReferenceCounting.Unsafe));
        }

        void RefCounting(Borrowed<PyObject> pyObject, IPythonReferenceCounting referenceCounting) {
            const int iterations = 400000;
            for (int iteration = 0; iteration < iterations; iteration++) {
                referenceCounting.Py_IncRef(pyObject);
                referenceCounting.Py_DecRef(pyObject);
            }
        }

        public ReferenceCountingBenchmark() {
            this.python.Py_Initialize();
            this.testObject = this.python.PyImport_ImportModule("builtins").DangerousGetHandle();
        }

        public void Dispose() {
            this.python.Py_Finalize();
        }
    }
}
