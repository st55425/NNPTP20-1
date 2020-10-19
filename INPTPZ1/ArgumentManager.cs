using INPTPZ1.Mathematics;
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
        private static readonly Resolution defaultResolution = new Resolution(300, 300);
        private static readonly string defaultSavePath = "../../../out.png";
        private static readonly GraphScope defaultGraphScope = new GraphScope(-1, 1, -1, 1);

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
            int pathIndex = 6;
            if (args.Length > pathIndex)
            {
                SavePath = args[pathIndex];
            }
            else
            {
                SavePath = defaultSavePath;
            }
            
        }

        private void ResolveImageResolution(string[] args)
        {
            int heightIndex = 0;
            int widthIndex =  1;
            if (args.Length > widthIndex && int.TryParse(args[heightIndex], out int height) && int.TryParse(args[widthIndex], out int width))
            {
                ImageResolution = new Resolution(height, width);
            }
            else
            {
                ImageResolution = defaultResolution;
            }
        }

        private void ResolveGraphScope(string[] args)
        {
            int XMinIndex = 2;
            int YMaxIndex = 5;
            if (args.Length > YMaxIndex && double.TryParse(args[XMinIndex], out double XMin) && 
                double.TryParse(args[XMinIndex+1], out double XMax) && 
                double.TryParse(args[XMinIndex+2], out double YMin) && 
                double.TryParse(args[YMaxIndex], out double YMax))
            {
                WorldGraphScope = new GraphScope(XMin, XMax, YMin, YMax);
            }
            else
            {
                WorldGraphScope = defaultGraphScope;
            }
        }
    }
}
