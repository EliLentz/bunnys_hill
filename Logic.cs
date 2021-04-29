using bunnys_hill;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bunnies
{
    public class Logic
    {
        #region GenerateBunnies
        /// <summary>
        /// A method for generating new random born bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns>A List of the generated bunnies</returns>
        public static List<Bunny> GenerateRandomBunnies(List<Bunny> currentBunnies)
        {
            List<Bunny> newBunnies = new List<Bunny>();

            int quantMaleBunnies = GetRegularAdultMaleBunnies(currentBunnies).Count;//quantity of regular adult male bunnies
            List<Bunny> femaleBunnies = GetRegularAdultFemaleBunnies(currentBunnies);//all current regular adult female bunnies

            Random random = new Random();

            foreach (Bunny fBunny in femaleBunnies)
            {
                for (int i = 0; i < quantMaleBunnies; i++)
                {
                    int generatedSex = random.Next(Enum.GetNames(typeof(Sex)).Length);
                    int generatedColor = (int)fBunny.Color;
                    string givenName;//the name is given from the list depending on the gender of the bunny

                    if (i % 2 == 0)// this so that there is an equal number of bunnies at the start
                    {
                        generatedSex = (int)Sex.Female;
                        givenName = ((FemaleNames)random.Next(Enum.GetNames(typeof(FemaleNames)).Length)).ToString();
                    }
                    else
                    {
                        generatedSex = (int)Sex.Male;
                        givenName = ((MaleNames)random.Next(Enum.GetNames(typeof(MaleNames)).Length)).ToString();
                    }

                    Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, Bunny.InitialAge);

                    newBunnies.Add(generatedBunny);
                }
            }

            Print.PrintNewBunnies(newBunnies);

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
                    generatedSex = (int)Sex.Female;
                    givenName = ((FemaleNames)random.Next(Enum.GetNames(typeof(FemaleNames)).Length)).ToString();
                }
                else
                {
                    generatedSex = (int)Sex.Male;
                    givenName = ((MaleNames)random.Next(Enum.GetNames(typeof(MaleNames)).Length)).ToString();
                }

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, Bunny.InitialAge);

                initialBunnies.Add(generatedBunny);
            }

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

        #endregion

        #region KillBunnies
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
                    Print.PrintDeadBunny(bunny);
                    currentBunnies.Remove(bunny);
                    Print.countDeadBunnies++;
                }
            }
        }

        /// <summary>
        /// this function kills half of randomly selected rabbits
        /// </summary>
        /// <param name="currentBunnies"></param>
        public static void KillHalf(List<Bunny> currentBunnies)
        {
            int qBunnies = currentBunnies.Count / 2; //half of the current bunnies

            Random random = new Random();

            while (currentBunnies.Count > qBunnies)//until the number of bunnies is equal to half of the current value, kill random bunnies
            {
                foreach (Bunny bunny in currentBunnies.ToList())
                {
                    if (currentBunnies.Count > qBunnies)//one more check for the accuracy of the statement that exactly half of the rabbits were removed and not one more
                    {
                        if (random.Next(2) == 1)
                        {
                            Print.PrintDeadBunny(bunny);
                            currentBunnies.Remove(bunny);
                            Print.countDeadBunnies++;
                        }
                    }
                    else return;
                }   
            }

        }

        #endregion

        #region RadioactiveMutantVampireFuctions

        /// <summary>
        /// every year the vampire bunny bites another regular rabbit and infects him with vampirism
        /// </summary>
        /// <param name="currentBunnies"></param>
        public static void DoBite(List<Bunny> currentBunnies)
        {
            List<Bunny> vampireBunnies = GetRadioactiveMutantVampireBunnies(currentBunnies);

            foreach (Bunny vampireBunny in vampireBunnies)
            {
                List<Bunny> regularBunneis = GetRegularBunnies(currentBunnies);
                IEnumerator<Bunny> regularBunniesEnumerator = regularBunneis.GetEnumerator();

                Random random = new Random();

                while(regularBunniesEnumerator.Current != regularBunneis[random.Next(regularBunneis.Count)])
                {
                    regularBunniesEnumerator.MoveNext();
                }

                regularBunniesEnumerator.Current.isRadioactiveMutantVampireBunny = true;

                Print.PrintVampireBunnies(regularBunniesEnumerator.Current);
            }
        }

        #endregion

        #region HelpFunctions

        #region Quantitative

        /// <param name="currentBunnies"></param>
        /// <returns>all regular adult male bunnies</returns>
        private static List<Bunny> GetRegularAdultMaleBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> maleBunnies = currentBunnies.Where(bunny => bunny.Sex == Sex.Male && bunny.isAdult && bunny.isRadioactiveMutantVampireBunny != true);

            return maleBunnies.ToList();
        }

        /// <param name="currentBunnies"></param>
        /// <returns>all regular adult female bunnies</returns>
        private static List<Bunny> GetRegularAdultFemaleBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> femaleBunnies = currentBunnies.Where(bunny => bunny.Sex == Sex.Female && bunny.isAdult && bunny.isRadioactiveMutantVampireBunny != true);

            return femaleBunnies.ToList();
        }

        #endregion

        #region Regular And Vampire
        /// <param name="currentBunnies"></param>
        /// <returns>all vampire bunnies</returns>
        public static List<Bunny> GetRadioactiveMutantVampireBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> radioactiveMutantVampireBunnies = currentBunnies.Where(bunny => bunny.isRadioactiveMutantVampireBunny == true);

            return radioactiveMutantVampireBunnies.ToList();
        }

        /// <param name="currentBunnies"></param>
        /// <returns>all regular bunnies</returns>
        private static List<Bunny> GetRegularBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> regularBunnies = currentBunnies.Where(bunny => bunny.isRadioactiveMutantVampireBunny != true);

            return regularBunnies.ToList();
        }
        #endregion

        #endregion
    }
}