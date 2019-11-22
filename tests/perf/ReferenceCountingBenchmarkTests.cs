namespace Python.Runtime.Native {
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
            Assert.IsTrue(
                condition: summary.Reports.All(r => r.Success),
                message: "BenchmarkDotNet failed to execute or collect results of performance tests. See logs above.");
        }
    }
}