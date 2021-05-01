namespace OrbitalViewer.Core.Polynomials
{
    public interface IPolynomial
    {
        double GetElement(int firstParameter, int secondParameter, double argument);
    }
}