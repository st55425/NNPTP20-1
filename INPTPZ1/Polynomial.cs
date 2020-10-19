using System;
using System.Collections.Generic;
using System.Numerics;

namespace INPTPZ1
{

    namespace Mathematics
    {
        public class Polynomial
        {
            public List<Complex> Coefficients { get;private set; }
            public List<Complex> FindedRoots { get;private set; }

            public Polynomial()
            {
                Coefficients = new List<Complex>();
                FindedRoots = new List<Complex>();
            }

            public Polynomial Derive()
            {
                Polynomial derivated = new Polynomial();
                for (int i = 1; i < Coefficients.Count; i++)
                {
                    derivated.Coefficients.Add(Coefficients[i] * i );
                }

                return derivated;
            }

            public Complex Evaluate(Complex value)
            {
                Complex result = Complex.Zero;
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    Complex coef = Coefficients[i];
                    if (i > 0)
                    {
                        coef *= Complex.Pow(value, i);
                    }

                    result += coef;
                }

                return result;
            }

            public override string ToString()
            {
                string s = "";
                for (int i = 0; i < Coefficients.Count; i++)
                {
                    s += Coefficients[i];
                    if (i > 0)
                    {
                        for (int j = 0; j < i; j++)
                        {
                            s += "x";
                        }
                    }
                    s += " + ";
                }
                return s;
            }
        }
    }
}
