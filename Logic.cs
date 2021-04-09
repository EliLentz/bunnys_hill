using bunnys_hill;
using System;

namespace Bunnies
{
    public class Logic
    {
        public static int count_newBunny = 0;//how many bunnies were born

        /// <summary>
        /// A method for generating random bunnies.
        /// </summary>
        /// <param name="numberOfBunnies"> How many bunnies to generate</param>
        /// <returns>  </returns>
        public static Bunny[] GenerateRandomBunnies(int numberOfBunnies)
        {
            Bunny[] bunny_arr = new Bunny[numberOfBunnies];

            Random random = new Random();
            for (int i = 0; i < numberOfBunnies; i++)
            {
                int generatedSex = random.Next(Enum.GetNames(typeof(Sex)).Length);
                int generatedColor = random.Next(Enum.GetNames(typeof(Color)).Length);
                string givenName;//the name is given from the list depending on the gender of the bunny

                if ((Sex)generatedSex == Sex.female)
                {
                    givenName = ((FemaleNames)random.Next(Enum.GetNames(typeof(FemaleNames)).Length)).ToString();
                }
                else
                {
                    givenName = ((MaleNames)random.Next(Enum.GetNames(typeof(MaleNames)).Length)).ToString();
                }

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, Bunny.InitialAge);

                bunny_arr[i] = generatedBunny;
            }
            PrintNewBunnies(bunny_arr);

            return bunny_arr;
        }

        /// <summary>
        /// A method for generating random bunnies, but with mother's color
        /// </summary>
        /// <param name="color"></param>
        /// <returns>An array of the generated bunnies</returns>
        public static Bunny[] GenerateRandomBunnies(int numberOfFemaleBunnies, int numberOfMaleBunnies, Color []color)
        {
            Bunny[] bunny_arr = new Bunny[numberOfFemaleBunnies*numberOfMaleBunnies];

            Random random = new Random();

            int ex_count = 0;

            for (int i = 0; i < numberOfFemaleBunnies; i++)
            {
                for (int j = 0; j < numberOfMaleBunnies; j++)
                {
                    int generatedSex = random.Next(Enum.GetNames(typeof(Sex)).Length);
                    int generatedColor = (int)color[i];//gives the rabbit the mother's color
                    string givenName;//the name is given from the list depending on the gender of the bunny

                    if ((Sex)generatedSex == Sex.female)
                    {
                        givenName = ((FemaleNames)random.Next(Enum.GetNames(typeof(FemaleNames)).Length)).ToString();
                    }
                    else
                    {
                        givenName = ((MaleNames)random.Next(Enum.GetNames(typeof(MaleNames)).Length)).ToString();
                    }

                    Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, Bunny.InitialAge);

                    bunny_arr[j + ex_count] = generatedBunny;
                }
                ex_count += numberOfMaleBunnies;
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
                int generatedColor = random.Next(Enum.GetNames(typeof(Color)).Length);
                int generatedSex;
                string givenName;//the name is given from the list depending on the gender of the bunny

                if (i % 2 == 0)// this so that there is an equal number of bunnies at the start
                {
                    generatedSex = (int)Sex.female;
                    givenName = ((FemaleNames)random.Next(Enum.GetNames(typeof(FemaleNames)).Length)).ToString();
                }
                else
                {
                    generatedSex = (int)Sex.male;
                    givenName = ((MaleNames)random.Next(Enum.GetNames(typeof(MaleNames)).Length)).ToString();
                }

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, Bunny.InitialAge);

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