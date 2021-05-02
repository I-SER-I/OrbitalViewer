using System;
using MathNet.Numerics;
using OrbitalViewer.Core.Models.Polynomials;

namespace OrbitalViewer.Core.Models.Functions
{
    public class RadialFunction
    {
        private const double BohrRadius = 10e-11 * 5.29177210903;
        private readonly int _principal;
        private readonly int _azimuthal;

        public RadialFunction(int principal, int azimuthal)
        {
            _principal = principal;
            _azimuthal = azimuthal;
        }

        public double GetValue(double radius)
        {
            double argument = 2 / (BohrRadius * _principal);
            double polynomialResult = new LaguerrePolynomial()
                .GetElement(2 * _azimuthal + 1, _principal - _azimuthal - 1, radius * argument);
            double sqrtPart = Math.Pow(argument, 3) * SpecialFunctions.Factorial(_principal - _azimuthal - 1) / 
                              (2 * _principal * SpecialFunctions.Factorial(_principal + _azimuthal));
            return Math.Sqrt(sqrtPart) * Math.Exp(-0.5 * radius * argument) * Math.Pow(radius * argument, _azimuthal) * polynomialResult;
        }
    }
}