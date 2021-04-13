using bunnys_hill;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bunnies
{
    public class Logic
    {
        public static int countNewBunnies = 0;//how many bunnies were born
        public static int countDeadBunnies = 0;//how many bunnies were died

        //functions of this region change the number of bunnies
        #region QuantitativeFunctions 
        /// <summary>
        /// A method for generating new random born bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns>A List of the generated bunnies</returns>
        public static List<Bunny> GenerateRandomBunnies(List<Bunny> currentBunnies)
        {
            List<Bunny> newBunnies = new List<Bunny>();

            int quantMaleBunnies = GetAdultMaleBunnies(currentBunnies).Count;//quantity of adult male bunnies
            List<Bunny> femaleBunnies = GetAdultFemaleBunnies(currentBunnies);//all current adult female bunnies

            Random random = new Random();

            foreach (Bunny bunny in currentBunnies)
            {
                for (int i = 0; i < quantMaleBunnies; i++)
                {
                    int generatedSex = random.Next(Enum.GetNames(typeof(Sex)).Length);
                    int generatedColor = (int)bunny.Color;
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

                    newBunnies.Add(generatedBunny);
                }
            }

            PrintNewBunnies(newBunnies);

            return newBunnies;
        }

        /// <summary>
        /// A method for generating random bunnies, but with initial genders.
        /// </summary>
        /// <param name="initialNumberOfBunnies"></param>
        /// <returns>A List of the generated bunnies</returns>
        public static List<Bunny> GenerateInitialBunnies(int initialNumberOfBunnies)
        {
            List<Bunny> initialBunnies = new List<Bunny>();

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

                initialBunnies.Add(generatedBunny);
            }
            PrintNewBunnies(initialBunnies);

            return initialBunnies;
        }

        /// <summary>
        /// this method adds one year to the bunny's age
        /// </summary>
        /// <param name="currentBunnies"></param>
        public static void AddYearToBunnies(List<Bunny> currentBunnies)
        {
            foreach (Bunny bunny in currentBunnies)
            {
                bunny.Age++;
            }
        }

        /// <summary>
        /// this method kills all bunnies over the age of 10
        /// </summary>
        /// <param name="currentBunnies"></param>
        public static void KillOldBunnies(List<Bunny> currentBunnies)
        {
            foreach (Bunny bunny in currentBunnies.ToList())
            {
                if (bunny.isOld)
                {
                    PrintDeadBunny(bunny);
                    currentBunnies.Remove(bunny);
                    countDeadBunnies++;
                }
            }
        }
        #endregion

        //functions of this region change the number of bunnies
        #region Print
        /// <summary>
        /// this method print the new bunnies, what were born this year
        /// </summary>
        /// <param name="bunny_arr"></param>
        public static void PrintNewBunnies(List<Bunny> newBunnies)
        {
            foreach (Bunny bunny in newBunnies)
            {
                Console.WriteLine("Bunny " + bunny.Name + " was born. Color: " + bunny.Color + ", Sex: " + bunny.Sex);
            }
            countNewBunnies = newBunnies.Count;
        }

        /// <summary>
        /// this method print the name of the dead bunny, what was died this year
        /// </summary>
        /// <param name="curDeadBunny"></param>
        public static void PrintDeadBunny(Bunny curDeadBunny) 
        {
            Console.WriteLine(curDeadBunny.Name + " died");
        }
        #endregion

        #region HelpFunctions
        /// <summary>
        /// this function get all adult male bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns></returns>
        private static List<Bunny> GetAdultMaleBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> maleBunnies = currentBunnies.Where(bunny => bunny.Sex == Sex.male && bunny.isAdult);

            return maleBunnies.ToList();
        }

        /// <summary>
        /// this function get all adult male bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns></returns>
        private static List<Bunny> GetAdultFemaleBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> femaleBunnies = currentBunnies.Where(bunny => bunny.Sex == Sex.female && bunny.isAdult);

            return femaleBunnies.ToList();
        }

        #endregion
    }
}