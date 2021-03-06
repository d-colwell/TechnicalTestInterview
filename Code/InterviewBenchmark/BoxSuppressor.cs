﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace InterviewBenchmark {
    public class BoxSuppressor {
        private readonly double jaqardIndex;
        private readonly double rankSuppressionValue;

        public BoxSuppressor(double jaqardIndex = 0.4, double rankSuppressionValue = 0.5) {
            this.jaqardIndex = jaqardIndex;
            this.rankSuppressionValue = rankSuppressionValue;
        }
        public List<Rectangle> SuppressTheBoxes(List<Rectangle> rectangles) {
            var rects = rectangles.Where(x=>x.rank >= rankSuppressionValue).ToList();

            Stopwatch t = new Stopwatch();
            t.Start();

            List<Rectangle> keep = new List<Rectangle>();
            List<Rectangle> discard = new List<Rectangle>();
            while (rects.Count > 0) {
                var best = rects[0];
                List<int> indicesToRemove = new List<int>();
                for (int i = 1; i < rects.Count; i++) {
                    if (JaqardIndex(best, rects[i]) >= jaqardIndex) {
                        indicesToRemove.Add(i);
                    }
                }
                indicesToRemove.Reverse();
                foreach (var indexToRemove in indicesToRemove) {
                    discard.Add(rects[indexToRemove]);
                    rects.RemoveAt(indexToRemove);
                }
                keep.Add(best);
                rects.RemoveAt(0);
            }
            t.Stop();
            Console.WriteLine($"{keep.Count} boxes kept, {discard.Count} removed in {t.ElapsedMilliseconds}ms");
            return keep;
        }

        public List<Rectangle> SuppressTheBoxes(string inputBoxFile) {
            var rects = ReadRectanglesFromFile(inputBoxFile);
            return SuppressTheBoxes(rects);
        }
        private List<Rectangle> ReadRectanglesFromFile(string inputBoxFile) {
            List<Rectangle> rects = new List<Rectangle>();
            using StreamReader reader = new StreamReader(inputBoxFile);
            reader.ReadLine(); //discard header
            while (!reader.EndOfStream) {
                string[] line = reader.ReadLine().Split(',', StringSplitOptions.RemoveEmptyEntries);

                int x1 = int.Parse(line[0]);
                int y1 = int.Parse(line[1]);
                int w = int.Parse(line[2]);
                int h = int.Parse(line[3]);
                int x2 = x1 + w;
                int y2 = y1 + h;

                double rank = double.Parse(line[4]);
                rects.Add(new Rectangle { x1 = x1, y1 = y1, x2 = x2, y2 = y2, rank = rank });
            }
            return rects;
        }
        private double JaqardIndex(Rectangle a, Rectangle b) {
            int ix1 = Math.Max(a.x1, b.x1);
            int iy1 = Math.Max(a.y1, b.y1);
            int ix2 = Math.Min(a.x2, b.x2);
            int iy2 = Math.Min(a.y2, b.y2);
            int iw = Math.Max(ix2 - ix1,0);
            int ih = Math.Max(iy2 - iy1,0);
            int intersect = iw * ih;
            if (intersect == 0) {
                return 0;
            }
            int union = RectArea(a) + RectArea(b) - intersect;
            return (double)intersect / (double)union;
        }

        private int RectArea(Rectangle a) {
            return (a.x2 - a.x1) * (a.y2 - a.y1);
        }
    }

    public struct Rectangle {
        public int x1;
        public int y1;
        public int x2;
        public int y2;
        public double rank;
        public int Width() => x2 - x1;
        public int Height() => y2 - y1;
    }
}
