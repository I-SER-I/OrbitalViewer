using System;

namespace OrbitalViewer.Core.Models.Functions
{
    public class WaveFunction
    {
        private readonly RadialFunction _radialFunction;
        private readonly SphericalFunction _sphericalFunction;

        public WaveFunction(int principalQuantumNumber, int orbitalQuantumNumber, int magneticQuantumNumber)
        {
            _radialFunction = new RadialFunction(principalQuantumNumber, orbitalQuantumNumber);
            _sphericalFunction = new SphericalFunction(orbitalQuantumNumber, magneticQuantumNumber);
        }

        public double GetValue(double radius, double theta, double phi) =>
            4 * Math.PI * Math.Pow(radius * _radialFunction.GetValue(radius) * _sphericalFunction.GetValue(theta, phi), 2);
    }
}