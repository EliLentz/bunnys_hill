using bunnys_hill;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Bunnies
{
    public class Logic
    {
        public static int countNewBunnies = 0;//how many bunnies were born
        public static int countDeadBunnies = 0;//how many bunnies were died

        private static bool stopFlow = false;//Regulates flow

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

                PrintVampireBunnies(regularBunniesEnumerator.Current);
            }
        }

        #endregion

        #region TimeOfHill

        /// <summary>
        /// This function pass a year every 3 seconds
        /// </summary>
        public static void RunTime()
        {
            const int timeOfSleeping = 3000;//a constant indicating how long the program should wait to skip a year

            Thread.Sleep(timeOfSleeping);

            Task taskStopper = Stopper();
            taskStopper.Start();

            while (stopFlow)
            {
                if (taskStopper.Status.Equals(true))
                {
                    taskStopper.Dispose();
                }
            }
        }

        /// <summary>
        /// This function stops the loops and outputting data to the console
        /// and print about status of the flow
        /// </summary>
        /// <returns>Task of stopper</returns>
        public static Task Stopper()
        {
            Task taskStopper = new Task(() => {
                while (Console.ReadKey().Key != ConsoleKey.Enter) ;
                if (stopFlow == false)
                {
                    stopFlow = true;
                    Console.WriteLine("Console operations have stopped");
                }
                else 
                {
                    stopFlow = false;
                    Console.WriteLine("Сonsole operations have resumed");
                }
            });
            return taskStopper;
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
                while (stopFlow) ;
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
            while (stopFlow) ;
            Console.WriteLine(curDeadBunny.Name + " died");
        }


        public static void PrintVampireBunnies(Bunny curVampireBunny)
        {
            while (stopFlow) ;
            Console.WriteLine(curVampireBunny.Name + " is radioactive mutant vampire. Age: " + curVampireBunny.Age + " Color: " + curVampireBunny.Color + " Sex: " + curVampireBunny.Sex) ;
        }
        #endregion

        #region HelpFunctions

        #region Quantitative
        /// <summary>
        /// this function gets all regular adult male bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns></returns>
        private static List<Bunny> GetRegularAdultMaleBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> maleBunnies = currentBunnies.Where(bunny => bunny.Sex == Sex.Male && bunny.isAdult && bunny.isRadioactiveMutantVampireBunny != true);

            return maleBunnies.ToList();
        }

        /// <summary>
        /// this function gets all regular adult female bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns></returns>
        private static List<Bunny> GetRegularAdultFemaleBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> femaleBunnies = currentBunnies.Where(bunny => bunny.Sex == Sex.Female && bunny.isAdult && bunny.isRadioactiveMutantVampireBunny != true);

            return femaleBunnies.ToList();
        }
        #endregion

        #region Regular And Vampire
        /// <summary>
        /// this function gets all radioactive mutant vampire bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns></returns>
        public static List<Bunny> GetRadioactiveMutantVampireBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> radioactiveMutantVampireBunnies = currentBunnies.Where(bunny => bunny.isRadioactiveMutantVampireBunny == true);

            return radioactiveMutantVampireBunnies.ToList();
        }

        /// <summary>
        /// this function gets all regular bunnies
        /// </summary>
        /// <param name="currentBunnies"></param>
        /// <returns></returns>
        private static List<Bunny> GetRegularBunnies(List<Bunny> currentBunnies)
        {
            IEnumerable<Bunny> regularBunnies = currentBunnies.Where(bunny => bunny.isRadioactiveMutantVampireBunny != true);

            return regularBunnies.ToList();
        }
        #endregion

        #endregion
    }
}