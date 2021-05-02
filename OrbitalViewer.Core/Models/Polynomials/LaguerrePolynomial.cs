namespace OrbitalViewer.Core.Models.Polynomials
{
    public class LaguerrePolynomial : IPolynomial
    {
        public double GetElement(int order, int degree, double argument)
        {
            return degree switch
            {
                0 => 1,
                1 => 1 + order - argument,
                _ => ((2 * (degree - 1) + 1 + order - argument) * GetElement(order, degree - 1, argument) -
                      (degree - 1 + order) * GetElement(order, degree - 2, argument)) / degree
            };
        }
    }
}