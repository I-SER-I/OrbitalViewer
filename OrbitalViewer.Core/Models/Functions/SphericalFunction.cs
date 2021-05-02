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

        public double GetValue(int order, int degree)
        {
            var laguerre = new LegendrePolynomial();
            double ePath = order >= 0 ? Math.Cos(order * _phi) : Math.Sin(Math.Abs(order) * _phi);
            double firstPath = (2 * degree + 1) / (4 * Math.PI);
            double secondPath = SpecialFunctions.Factorial(degree - Math.Abs(order)) /
                                SpecialFunctions.Factorial(degree + Math.Abs(order));
            var normalCoeff = Math.Sqrt(2) * Math.Sqrt(firstPath * secondPath);
            return normalCoeff * laguerre.GetElement(degree, order, Math.Cos(_theta * Math.PI / 180)) * ePath;
        }
    }
}