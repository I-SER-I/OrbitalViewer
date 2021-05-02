namespace OrbitalViewer.Core.Models.Polynomials
{
    public interface IPolynomial
    {
        double GetElement(int degree, int order, double argument);
    }
}