using System;

namespace OrbitalViewer.Core.Models.Polynomials
{
    public class LegendrePolynomial : IPolynomial
    {
        public double GetElement(int degree, int order, double argument)
        {
            if (degree < order) return 0;
            if (degree == 0 && order == 0) return 1;
            if (degree == 1 && order == 0) return argument;
            if (degree == order)
            {
                double sign = order % 2 == 0 ? 1 : -1;
                for (double i = 2 * order - 1; i > 1; i -= 2)
                {
                    sign *= i;
                }

                return sign * Math.Pow(1 - argument * argument, (double) order / 2);
            }

            return ((2 * degree - 1) * argument * GetElement(degree - 1, order, argument) -
                    (degree + order - 1) * GetElement(degree - 2, order, argument)) / (degree - order);
        }
    }
}