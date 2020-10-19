using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class FractalPoint
    {
        public Complex Position { get; set; }
        public Complex Root  { get; set; }
        public int IterationCount { get; set; }

        public FractalPoint(Complex position, Complex root, int iterationCount)
        {
            Position = position;
            Root = root;
            IterationCount = iterationCount;
        }
    }
}
