namespace OrbitalViewer.Core.Models.Polynomials
{
    public interface IPolynomial
    {
        double GetElement(int firstParameter, int secondParameter, double argument);
    }
}