using INPTPZ1.Mathematics;
using Mathematics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class FractalManager
    {
        public readonly static double Tolerance = 0.01;
        public Polynomial ExaminedFunction { get; private set; }
        public GraphScope WorldGraphScope { get; private set; }
        public Resolution TotalDots { get; private set; }

        private NewtonIteration newtonIteration;


        public FractalManager(Polynomial examinedFunction, GraphScope worldGraphScope, Resolution totalDots)
        {
            ExaminedFunction = examinedFunction;
            WorldGraphScope = worldGraphScope;
            TotalDots = totalDots;
            newtonIteration = new NewtonIteration(examinedFunction);
        }

        public FractalPoint ComputePoint(int xPosition, int yPosition)
        {
            Complex graphPosition = FindGraphPoint(xPosition, yPosition);
            return newtonIteration.FindRoot(graphPosition);

        }

        public int GetRootNumber(Complex root)
        {
            for (int i = 0; i < ExaminedFunction.FindedRoots.Count; i++)
            {
                if (RootEquals(root, ExaminedFunction.FindedRoots[i]))
                {
                    return i;
                }
            }
            ExaminedFunction.FindedRoots.Add(root);
            return ExaminedFunction.FindedRoots.Count;
        }

        private bool RootEquals(Complex root1, Complex root2)
        {
            return Math.Pow(root1.Real - root2.Real, 2) + Math.Pow(root1.Imaginary - root2.Imaginary, 2) <= Tolerance;
        }

        private Complex FindGraphPoint(int xPosition, int yPosition)
        {
            double xstep = (WorldGraphScope.XMax - WorldGraphScope.XMin) / TotalDots.Width;
            double ystep = (WorldGraphScope.YMax - WorldGraphScope.YMin) / TotalDots.Height;

            double graphXPosition = WorldGraphScope.XMin + xPosition * xstep;
            double graphYPosition = WorldGraphScope.YMin + yPosition * ystep;

            return new Complex(graphXPosition, graphYPosition);
        }
    }
}
