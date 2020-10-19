using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class ImageManager
    {
        public readonly static Color[] BaseColors = new Color[]
            {
                Color.Red, Color.Blue, Color.Green, Color.Yellow, Color.Orange, Color.Fuchsia, Color.Gold, Color.Cyan, Color.Magenta
            };

        public Bitmap Image { get;private set; }
        private FractalManager fractalManager;
        private Resolution ImageResolution;

        public ImageManager(FractalManager fractalManager)
        {
            this.fractalManager = fractalManager;
            ImageResolution = fractalManager.TotalDots;
            Image = new Bitmap(ImageResolution.Width, ImageResolution.Height);
        }

        public void ColorizeFractal()
        {
            for (int x = 0; x < ImageResolution.Width; x++)
            {
                for (int y = 0; y < ImageResolution.Height; y++)
                {
                    ColorizePixel(x, y);
                }
            }
        }

        public void SaveImage(string path)
        {
            Image.Save(path);
        }

        private void ColorizePixel(int x, int y)
        {
            FractalPoint fractalPoint = fractalManager.ComputePoint(x, y);
            Color baseColor = BaseColors[fractalManager.GetRootNumber(fractalPoint.Root) % BaseColors.Length];
            Color pixelColor = ResolveColor(baseColor, fractalPoint.IterationCount);

            Image.SetPixel(x, y, pixelColor);
        }

        private Color ResolveColor(Color baseColor, int iterationCount)
        {
            int RValue = Math.Min(Math.Max(0, baseColor.R - iterationCount * 2), byte.MaxValue);
            int GValue = Math.Min(Math.Max(0, baseColor.G - iterationCount * 2), byte.MaxValue);
            int BValue = Math.Min(Math.Max(0, baseColor.B - iterationCount * 2), byte.MaxValue);
            return Color.FromArgb(RValue, GValue, BValue);
        }


    }
}
