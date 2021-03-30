using bunnys_hill;
using Hill;
using System;

namespace Bunnies
{
    public class Logic
    {

        const int MAX_AGE = 11; //0 - 10 (useless)

        const int InitialAge = 0;

        static Hill<Bunny> hill = new Hill<Bunny>(); //list of the bunnys on hill

        /// <summary>
        /// A method for generating random bunnies.
        /// </summary>
        /// <param name="numberOfBunnies"> How many bunnies to generate</param>
        /// <returns> An array of the generated bunnies </returns>
        public static void GenerateRandomBunnies(int numberOfBunnies)
        {
            Random random = new Random();
            for (int i = 0; i < numberOfBunnies; i++)
            {
                int generatedSex = random.Next(Enum.GetNames(typeof(Sex)).Length);
                int generatedColor = random.Next(Enum.GetNames(typeof(Color)).Length);

                Console.Write("Please, Enter Bunny's name: ");

                string givenName = Console.ReadLine();

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, InitialAge);

                hill.Push_Back(generatedBunny);
            }
        }
    }
}