namespace OrbitalViewer.Core.Models
{
    public static class SpecialFunctions
    {
        public static double Factorial(int number) => number == 0 ? 1 : number * Factorial(number - 1);
    }
}