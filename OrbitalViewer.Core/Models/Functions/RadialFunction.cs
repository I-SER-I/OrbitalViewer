using System;
using OrbitalViewer.Core.Models.Polynomials;

namespace OrbitalViewer.Core.Models.Functions
{
    public class RadialFunction
    {
        private const double BohrRadius = 5.29177210903e-11;
        private readonly int _principal;
        private readonly int _orbital;

        public RadialFunction(int principal, int orbital)
        {
            _principal = principal;
            _orbital = orbital;
        }

        public double GetValue(double radius)
        {
            double argument = 2 / (BohrRadius * _principal);
            double polynomialResult = new LaguerrePolynomial()
                .GetElement(2 * _orbital + 1, _principal - _orbital - 1, radius * argument);
            double sqrtPart = Math.Pow(argument, 3) * SpecialFunctions.Factorial(_principal - _orbital - 1) / 
                              (2 * _principal * SpecialFunctions.Factorial(_principal + _orbital));
            return Math.Sqrt(sqrtPart) * Math.Exp(-0.5 * radius * argument) * Math.Pow(radius * argument, _orbital) * polynomialResult;
        }
    }
}