using bunnys_hill;
using Hill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bunnies
{
    public class Program
    {
        static void Main(string[] args)
        {
            Logic.GenerateRandomBunnies(5); //giving random features (color and gender)for the bunnies

            Console.ReadKey();

        }
    }
}