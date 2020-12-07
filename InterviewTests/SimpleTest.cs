using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace InterviewTests {
    [TestClass]
    public class SimpleTest {
        [TestMethod]
        public void CheckProgramIsRunning() {
            InterviewBenchmark.Program.Main(new string[] { "smoke-test.csv" });
            Assert.IsTrue(File.Exists("output.csv"));
            var lines = File.ReadAllLines("output.csv");
            //Validate that the second line contains the correct record
            Assert.AreEqual(lines[1], "1,1,10,10,0.5");

        }
    }
}
