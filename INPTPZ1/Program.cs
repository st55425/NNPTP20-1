using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.Drawing.Text;
using System.Linq.Expressions;
using System.Threading;
using INPTPZ1.Mathematics;
using System.Numerics;

namespace INPTPZ1
{
    /// <summary>
    /// This program should produce Newton fractals.
    /// See more at: https://en.wikipedia.org/wiki/Newton_fractal
    /// </summary>
    class Program
    {
        static Polynomial DefaultExaminedPolynomial()
        {
            Polynomial defaultPolynomial = new Polynomial();
            defaultPolynomial.Coefficients.Add(Complex.One);
            defaultPolynomial.Coefficients.Add(Complex.Zero);
            defaultPolynomial.Coefficients.Add(Complex.Zero);
            defaultPolynomial.Coefficients.Add(Complex.One);
            return defaultPolynomial;
        }

        static void Main(string[] args)
        {
            ArgumentManager argumentManager = new ArgumentManager(args);
            FractalManager fractalManager = new FractalManager(DefaultExaminedPolynomial(), argumentManager.WorldGraphScope, argumentManager.ImageResolution);
            ImageManager imageManager = new ImageManager(fractalManager);
            imageManager.ColorizeFractal();
            imageManager.SaveImage(argumentManager.SavePath);
        }
    }
}