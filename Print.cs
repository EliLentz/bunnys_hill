using bunnys_hill;
using NLog;
using System;
using System.Collections.Generic;

namespace Bunnies
{
    public class Print
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region AboutBunnies
        public static int countNewBunnies = 0;//how many bunnies were born
        public static int countDeadBunnies = 0;//how many bunnies were died

        /// <summary>
        /// prints new bunnies
        /// </summary>
        /// <param name="newBunny"></param>
        public static void PrintNewBunny(Bunny newBunny)
        {
            while (Times.stopFlow) ;
            logger.Info("Bunny " + newBunny.Name + " was born. Color: " + newBunny.Color + ", Sex: " + newBunny.Sex);
            Console.WriteLine("Bunny " + newBunny.Name + " was born. Color: " + newBunny.Color + ", Sex: " + newBunny.Sex);

            countNewBunnies++;
        }

        /// <summary>
        /// prints info about new bunnies in list of bunnies
        /// </summary>
        /// <param name="newBunnies"></param>
        public static void PrintNewBunnies(List<Bunny> newBunnies)
        {
            foreach (Bunny bunny in newBunnies)
            {
                if (!bunny.isRadioactiveMutantVampireBunny)
                {
                    PrintNewBunny(bunny);
                }
                else
                {
                    PrintVampireBunny(bunny);

                    countNewBunnies++;//it's also new bunny
                }
            }
        }

        /// <summary>
        /// this method print the name of the dead bunny, what was died this year
        /// </summary>
        /// <param name="curDeadBunny"></param>
        public static void PrintDeadBunny(Bunny curDeadBunny)
        {
            while (Times.stopFlow) ;
            logger.Info(curDeadBunny.Name + " died");
            Console.WriteLine(curDeadBunny.Name + " died");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="curVampireBunny"></param>
        public static void PrintVampireBunny(Bunny curVampireBunny)
        {
            while (Times.stopFlow) ;
            logger.Info(curVampireBunny.Name + " is radioactive mutant vampire. Age: " + curVampireBunny.Age + " Color: " + curVampireBunny.Color + " Sex: " + curVampireBunny.Sex);
            Console.WriteLine(curVampireBunny.Name + " is radioactive mutant vampire. Age: " + curVampireBunny.Age + " Color: " + curVampireBunny.Color + " Sex: " + curVampireBunny.Sex);
        }
        #endregion

        #region AboutYear

        /// <summary>
        /// prints all quantitative bunnies changes over the year
        /// </summary>
        /// <param name="bunnies"></param>
        public static void PrintBunniesChangesOverTheYear(List<Bunny> bunnies)
        {
            logger.Info("Born: " + Print.countNewBunnies);
            logger.Info("Died: " + Print.countDeadBunnies);
            logger.Info("Radioactive Mutant Vampire: " + Logic.GetRadioactiveMutantVampireBunnies(bunnies).Count);
            Console.WriteLine("Born: " + Print.countNewBunnies + "\nDied: " + Print.countDeadBunnies + "\nRadioactive Mutant Vampire: " + Logic.GetRadioactiveMutantVampireBunnies(bunnies).Count);

            //after printing the year info this values should be zeroed
            //they valid only for the current year
            countDeadBunnies = 0;
            countNewBunnies = 0;
        }

        /// <summary>
        /// prints current year info
        /// </summary>
        public static void PrintYearInfo(int currentYear)
        {
            logger.Info("Year " + currentYear + " has passed");
            Console.WriteLine("Year " + currentYear + " has passed");
        }

        #endregion
    }
}