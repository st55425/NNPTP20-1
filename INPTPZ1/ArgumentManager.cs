using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class ArgumentManager
    {
        private static readonly Resolution DefaultResolution = new Resolution(300, 300);
        private static readonly string DefaultSavePath = "../../../out.png";
        private static readonly GraphScope DefaultGraphScope = new GraphScope(-1, 1, -1, 1);

        private const int HeightIndex = 0;
        private const int WidthIndex = 1;
        private const int XMinIndex = 2;
        private const int XMaxIndex = 3;
        private const int YMinIndex = 4;
        private const int YMaxIndex = 5;
        private const int SavePathIndex = 6;

        public Resolution ImageResolution { get;private set; }
        public string SavePath { get;private set; }
        public GraphScope WorldGraphScope { get; private set; }

        public ArgumentManager(string[] args)
        {
            ResolveImageResolution(args);
            ResolveGraphScope(args);
            ResolveSavePath(args);
        }

        private void ResolveSavePath(string[] args)
        {
            if (args.Length > SavePathIndex)
            {
                SavePath = args[SavePathIndex];
            }
            else
            {
                SavePath = DefaultSavePath;
            }
            
        }

        private void ResolveImageResolution(string[] args)
        {
            if (args.Length > WidthIndex && int.TryParse(args[HeightIndex], out int height) && int.TryParse(args[WidthIndex], out int width))
            {
                ImageResolution = new Resolution(height, width);
            }
            else
            {
                ImageResolution = DefaultResolution;
            }
        }

        private void ResolveGraphScope(string[] args)
        {
            if (args.Length > YMaxIndex && 
                double.TryParse(args[XMinIndex], out double XMin) && 
                double.TryParse(args[XMaxIndex], out double XMax) && 
                double.TryParse(args[YMinIndex], out double YMin) && 
                double.TryParse(args[YMaxIndex], out double YMax))
            {
                WorldGraphScope = new GraphScope(XMin, XMax, YMin, YMax);
            }
            else
            {
                WorldGraphScope = DefaultGraphScope;
            }
        }
    }
}
