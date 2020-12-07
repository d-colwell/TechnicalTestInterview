using InterviewBenchmark;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace InterviewTests {
    [TestClass]
    public class SmokeTests {
        [TestMethod]
        public void CheckProgramIsRunning() {
            InterviewBenchmark.Program.Main(new string[] { "smoke-test.csv" });
            Assert.IsTrue(File.Exists("output.csv"));
            var lines = File.ReadAllLines("output.csv");
            //Validate that the second line contains the correct record
            Assert.AreEqual(lines[1], "1,1,10,10,0.5");

        }

        [TestMethod]
        public void CheckRankThreshold() {
            var boxSuppressor = new InterviewBenchmark.BoxSuppressor();
            List<Rectangle> rectangles = boxSuppressor.SuppressTheBoxes("check-rank-threshold.csv");
            Assert.IsTrue(rectangles.Min(r => r.rank) > 0.6);
        }
    }
}
