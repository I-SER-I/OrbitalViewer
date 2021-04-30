namespace OrbitalViewer.Core.Polynomials
{
    public class LaguerrePolynomial : IPolynomial
    {
        public double GetElement(double alpha, double k, double argument)
        {
            return k switch
            {
                0 => 1,
                1 => 1 + alpha - argument,
                _ => ((2 * (k - 1) + 1 + alpha - argument) * GetElement(alpha, k - 1, argument) -
                      (k - 1 + alpha) * GetElement(alpha, k - 2, argument)) / k
            };
        }
    }
}