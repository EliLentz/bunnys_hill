using bunnys_hill;
using System;

namespace Bunnies
{
    public class Logic
    {
        public const int MAX_AGE = 10;//maximum age of bunny
        public const int ADULT_AGE = 2;//from 2 - 10 bunny is adult and ready to care the kids
        const int InitialAge = 0;

        ///static int count_name = 0;// this is for laziest + line 33 and 39

        /// <summary>
        /// A method for generating random bunnies.
        /// </summary>
        /// <param name="numberOfBunnies"> How many bunnies to generate</param>
        /// <returns> An array of the generated bunnies </returns>
        public static Bunny[] GenerateRandomBunnies(int numberOfBunnies)
        {
            Bunny[] bunny_arr = new Bunny[numberOfBunnies];

            Random random = new Random();
            for (int i = 0; i < numberOfBunnies; i++)
            {
                int generatedSex = random.Next(Enum.GetNames(typeof(Sex)).Length);
                int generatedColor = random.Next(Enum.GetNames(typeof(Color)).Length);

                Console.Write("Please, Enter " + (Sex)generatedSex + " Bunny's name: ");

                string givenName = Console.ReadLine();

                ///string givenName = count_name.ToString(); this is for laziest + line 12 and 39

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, InitialAge);

                bunny_arr[i] = generatedBunny;

                ///count_name++; //this is for laziest + line 12 and 33
            }

            return bunny_arr;
        }

        /// <summary>
        /// A method for generating random bunnies, but with initial genders.
        /// </summary>
        /// <param name="initialNumberOfBunnies"></param>
        /// <returns>An array of the generated bunnies</returns>
        public static Bunny[] GenerateInitialBunnies(int initialNumberOfBunnies)
        {
            Bunny[] bunny_arr = new Bunny[initialNumberOfBunnies];

            Random random = new Random();

            for (int i = 0; i < initialNumberOfBunnies; i++)
            {
                int generatedSex;
                if (i % 2 == 0)//
                {
                    generatedSex = (int)Sex.female;
                }
                else
                {
                    generatedSex = (int)Sex.male;
                }
                int generatedColor = random.Next(Enum.GetNames(typeof(Color)).Length);

                Console.Write("Please, Enter " + (Sex)generatedSex + " Bunny's name: ");

                string givenName = Console.ReadLine();

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, InitialAge);

                bunny_arr[i] = generatedBunny;
            }

            return bunny_arr;
        }
    }
}