using bunnys_hill;
using System;
using System.Collections.Generic;
using System.Linq;

namespace End
{
    class DoEnd
    {
        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        /// <param name="currentBunnies"></param>
        /// <returns>the status of the list (there are only regular bunneis in the list or not)</returns>
        public static bool StatusVampireApocalype(List<Bunny> currentBunnies)
        {
            bool isStatus = false;

            if (GetAllRadioactiveMutantVampire(currentBunnies).Count == currentBunnies.Count)
            {
                isStatus = true;
            }

            return isStatus;
        }

        public static void PrintEnd()
        {
            logger.Info("The cycle has ended, as only radioactive vampire rabbits remained on the watership, and soon their population would completely die out.");
            Console.WriteLine("\nThe cycle has ended, as only radioactive vampire rabbits remained on the watership, and soon their population would completely die out.");
        }

        /// <param name="currentBunnies"></param>
        /// <returns>all vampire bunnies</returns>
        private static List<Bunny> GetAllRadioactiveMutantVampire(List<Bunny> currentBunnies)
        {
            return currentBunnies.Where(bunny => bunny.isRadioactiveMutantVampireBunny == true).ToList();
        }

    }
}
