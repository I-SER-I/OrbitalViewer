using System;
using MathNet.Numerics;
using OrbitalViewer.Core.Models.Polynomials;

namespace OrbitalViewer.Core.Models.Functions
{
    public class SphericalFunction
    {
        private readonly double _theta;
        private readonly double _phi;

        public SphericalFunction(double theta, double phi)
        {
            _theta = theta;
            _phi = phi;
        }

        public double GetValue(int magnetic, int azimuthal)
        {
            var laguerre = new LegendrePolynomial();
            double ePart = magnetic >= 0 ? Math.Cos(magnetic * _phi) : Math.Sin(Math.Abs(magnetic) * _phi);
            double firstPart = (2 * azimuthal + 1) / (4 * Math.PI);
            double secondPart = SpecialFunctions.Factorial(azimuthal - Math.Abs(magnetic)) /
                                SpecialFunctions.Factorial(azimuthal + Math.Abs(magnetic));
            double normalCoeff = Math.Sqrt(2) * Math.Sqrt(firstPart * secondPart);
            double argument = Math.Cos(_theta * Math.PI / 180) * ePart;
            return normalCoeff * laguerre.GetElement(azimuthal, magnetic, argument);
        }
    }
}