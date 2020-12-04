using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Timers;

namespace InterviewBenchmark {
    class Program {
        static void Main(string[] args) {
            string inputFile = "boxes.csv";
            double jaqardIndex = 0.4;
            double suppressionValue = 0.5;
            if (args.Length > 0) {
                inputFile = args[0];
                if (args.Length > 1)
                    jaqardIndex = double.Parse(args[1]);
                if (args.Length > 2)
                    suppressionValue = double.Parse(args[2]);
            }
            Console.WriteLine($"Input file {inputFile}, JaqardIndex: {jaqardIndex}, SuppressionThreshold: {suppressionValue}");
            BoxSuppressor b = new BoxSuppressor(jaqardIndex,suppressionValue);
            var rects = b.SuppressTheBoxes(inputFile);
        }

        private static void WriteToOutputFile(List<Rectangle> rectangles) {
            //do this later
        }


    }

}