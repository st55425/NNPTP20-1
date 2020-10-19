using INPTPZ1;
using INPTPZ1.Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Mathematics
{
    class NewtonIteration
    {
        public readonly static int MaxIterations = 30;
        public readonly static double MinimalDivisor = 0.0001;
        public Polynomial ExaminedFunction { get; set; }
        public Polynomial DerivedFunction { get => ExaminedFunction.Derive(); }

        public NewtonIteration(Polynomial examinedFunction)
        {
            ExaminedFunction = examinedFunction;
        }

        public FractalPoint FindRoot(Complex initialGuess)
        {
            Polynomial derivated = ExaminedFunction.Derive();
            int iterationsCount = 0;
            Complex root = initialGuess;
            for (int i = 0; i < MaxIterations; i++)
            {
                Complex difference = ExaminedFunction.Evaluate(root) / derivated.Evaluate(root);
                root -= difference;

                if (IsBigDifference(difference))
                {
                    i--;
                }
                iterationsCount++;
                if (Math.Abs(root.Magnitude) < MinimalDivisor)
                {
                    break;
                }
            }
            return new FractalPoint(initialGuess, root, iterationsCount);
        }

        private bool IsBigDifference(Complex difference)
        {
            return Math.Pow(difference.Real, 2) + Math.Pow(difference.Imaginary, 2) >= 0.5;
        }
    }
}
