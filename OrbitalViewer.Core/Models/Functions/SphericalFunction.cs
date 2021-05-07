using System;
using OrbitalViewer.Core.Models.Polynomials;

namespace OrbitalViewer.Core.Models.Functions
{
    public class SphericalFunction
    {
        private readonly int _orbital;
        private readonly int _magnetic;

        public SphericalFunction(int orbital, int magnetic)
        {
            _orbital = orbital;
            _magnetic = magnetic;
        }

        public double GetValue(double theta, double phi)
        {
            var laguerre = new LegendrePolynomial();
            double ePart = _magnetic >= 0 ? Math.Cos(_magnetic * phi) : Math.Sin(Math.Abs(_magnetic) * phi);
            double firstPart = (2 * _orbital + 1) / (4 * Math.PI);
            double secondPart = SpecialFunctions.Factorial(_orbital - Math.Abs(_magnetic)) /
                                SpecialFunctions.Factorial(_orbital + Math.Abs(_magnetic));
            double normalCoefficient = Math.Sqrt(2) * Math.Sqrt(firstPart * secondPart);
            double argument = Math.Cos(theta * Math.PI / 180) * ePart;
            return normalCoefficient * laguerre.GetElement(_orbital, _magnetic, argument);
        }
    }
}