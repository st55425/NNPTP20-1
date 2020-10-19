using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class Resolution
    {
        public int Height { get; private set; }
        public int Width { get; private set; }

        public Resolution(int height, int width)
        {
            Height = height;
            Width = width;
        }
    }
}
