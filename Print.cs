using bunnys_hill;
using NLog;
using System;
using System.Collections.Generic;

namespace Bunnies
{
    public class Print
    {
        public static int countNewBunnies = 0;//how many bunnies were born
        public static int countDeadBunnies = 0;//how many bunnies were died

        private static Logger logger = LogManager.GetCurrentClassLogger();

        public static void PrintNewBunnies(List<Bunny> newBunnies)
        {
            foreach (Bunny bunny in newBunnies)
            {
                while (Times.stopFlow) ;
                logger.Info("Bunny " + bunny.Name + " was born. Color: " + bunny.Color + ", Sex: " + bunny.Sex);
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
            while (Times.stopFlow) ;
            logger.Info(curDeadBunny.Name + " died");
            Console.WriteLine(curDeadBunny.Name + " died");
        }


        public static void PrintVampireBunnies(Bunny curVampireBunny)
        {
            while (Times.stopFlow) ;
            logger.Info(curVampireBunny.Name + " is radioactive mutant vampire. Age: " + curVampireBunny.Age + " Color: " + curVampireBunny.Color + " Sex: " + curVampireBunny.Sex);
            Console.WriteLine(curVampireBunny.Name + " is radioactive mutant vampire. Age: " + curVampireBunny.Age + " Color: " + curVampireBunny.Color + " Sex: " + curVampireBunny.Sex);
        }

    }
}