using bunnys_hill;
using System;

namespace Bunnies
{
    public class Logic
    {
        public const int MAX_AGE = 10;//maximum age of bunny
        public const int ADULT_AGE = 2;//from 2 - 10 bunny is adult and ready to care the kids
        const int InitialAge = 0;

        public static int count_newBunny = 0;//how many bunnies were born

        ///static int count_name = 0;// this is for laziest + line 33 and 39(integer names)

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

                Console.Write("Please, Enter " + (Sex)generatedSex + " Bunny's name: ");//for custom names

                string givenName = Console.ReadLine();//for custom names

                ///string givenName = count_name.ToString();// this is for laziest + line 12 and 39(integer names)

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, InitialAge);

                bunny_arr[i] = generatedBunny;

                ///count_name++; //this is for laziest + line 12 and 33(integer names)
            }
            PrintNewBunnies(bunny_arr);

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
                if (i % 2 == 0)// this so that there is an equal number of bunnies at the start
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
            PrintNewBunnies(bunny_arr);

            return bunny_arr;
        }

        /// <summary>
        /// this method print the new bunnies, what were born this year
        /// </summary>
        /// <param name="bunny_arr"></param>
        public static void PrintNewBunnies(Bunny [] bunny_arr)
        {
            for (int i = 0; i < bunny_arr.Length; i++)
            {
                Console.WriteLine("Bunny " + bunny_arr[i].Name + " was born. Color: " + (Color)bunny_arr[i].Color + ", Sex: " + (Sex)bunny_arr[i].Sex);
            }
            count_newBunny = bunny_arr.Length;
        }
    }
}