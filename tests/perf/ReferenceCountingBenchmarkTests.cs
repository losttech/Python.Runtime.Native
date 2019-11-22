namespace Python.Runtime.Native {
    using System;
    using System.Linq;
    using BenchmarkDotNet.Running;
    using NUnit.Framework;

    public class ReferenceCountingBenchmarkTests {
        [SetUp]
        public void Setup() {
        }

        [Test]
        public void ReferenceCountingBenchmark() {
            var summary = BenchmarkRunner.Run<ReferenceCountingBenchmark>();
            Assert.IsFalse(summary.HasCriticalValidationErrors,
                message: string.Join(Environment.NewLine, summary.ValidationErrors));
            Assert.NotZero(actual: summary.Reports.Length,
                message: "Number of benchmark reports");
            Assert.IsTrue(
                condition: summary.Reports.All(r => r.Success),
                message: "BenchmarkDotNet failed to execute or collect results of performance tests. See logs above.");
        }
    }
}