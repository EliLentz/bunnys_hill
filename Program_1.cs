using bunnys_hill;

namespace Bunnies
{
    public class Program
    {
        static void Main(string[] args)
        {
            Bunny[] bunnies; ;//creating initial bunnies

            bunnies = Logic.GenerateInitialBunnies(5); //giving random features (color and gender)for the bunnies

            Hill.Hill hill = new Hill.Hill(bunnies); //starting the circly of bunny's life
        }
    }
}