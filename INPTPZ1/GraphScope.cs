using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace INPTPZ1
{
    public class GraphScope
    {
        public double XMin { get; private set; }
        public double XMax { get;private set; }
        public double YMin { get; private set; }
        public double YMax { get; private set; }

        public GraphScope(double xMin, double xMax, double yMin, double yMax)
        {
            XMin = xMin;
            XMax = xMax;
            YMin = yMin;
            YMax = yMax;
        }
    }
}
