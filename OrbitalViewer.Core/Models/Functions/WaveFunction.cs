using System;

namespace OrbitalViewer.Core.Models.Functions
{
    public class WaveFunction
    {
        private readonly RadialFunction _radialFunction;
        private readonly SphericalFunction _specialFunctions;

        public WaveFunction(int principalQuantumNumber, int azimuthalQuantumNumber, int magneticQuantumNumber)
        {
            _radialFunction = new RadialFunction(principalQuantumNumber, azimuthalQuantumNumber);
            _specialFunctions = new SphericalFunction(azimuthalQuantumNumber, magneticQuantumNumber);
        }

        public double GetValue(double radius, double theta, double phi) =>
            Math.Pow(_radialFunction.GetValue(radius) * _specialFunctions.GetValue(theta, phi), 2);
    }
}