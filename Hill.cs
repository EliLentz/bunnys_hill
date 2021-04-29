using Bunnies;
using bunnys_hill;
using End;
using NLog;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hill
{
    /// <summary>
    /// here we will use a list to save and control all the bunnies
    /// </summary>
    class Hill
    {
        List<Bunny> _hill = new List<Bunny>();// the list of bunnys
        public static int CUR_YEAR { get; private set; } //current year (starts from 0)

        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Ctor
        /// <summary>
        /// the constructor that starts the "loop"
        /// </summary>
        /// <param name="bunnies">For start circle, constructor needs minimum 2 bunnies(male and female)</param>
        public Hill(List<Bunny> bunnies)
        {
            

            foreach (Bunny bunny in bunnies)//add initial bunnies to the loop
            {
                _hill.Add(bunny);
            }

            Print.PrintNewBunnies(bunnies);

            RunCycle();
        }
        #endregion

        /// <summary>
        /// this method starts the life cycle of bunnies
        /// </summary>
        private void RunCycle()
        {
            while (!DoEnd.StatusVampireApocalype(_hill))//As long as there is at least one regular bunny, the program will keep working.
            {
                Task taskStopper = Times.Stopper();

                taskStopper.Start();

                if (_hill.Count > 500)//if the quantity of bunnies is more then 500, they will die by natural causes
                {
                    Logic.KillHalf(_hill);
                }

                Logic.KillOldBunnies(_hill);
                Logic.DoBite(_hill);
                List<Bunny> newBunnies = Logic.GenerateRandomBunnies(_hill);
                foreach (Bunny bunny in newBunnies)
                {
                    _hill.Add(bunny);
                }

                Logic.AddYearToBunnies(_hill);

                logger.Info("Born: " + Print.countNewBunnies);
                logger.Info("Died: " + Print.countDeadBunnies);
                logger.Info("Radioactive Mutant Vampire: " + Logic.GetRadioactiveMutantVampireBunnies(_hill).Count);
                Console.WriteLine("Born: " + Print.countNewBunnies + "\nDied: " + Print.countDeadBunnies + "\nRadioactive Mutant Vampire: " + Logic.GetRadioactiveMutantVampireBunnies(_hill).Count);

                Print.countDeadBunnies = 0;
                Print.countNewBunnies = 0;

                Times.RunTime();

                logger.Info("Year " + CUR_YEAR + " has passed");
                Console.WriteLine("Year " + CUR_YEAR + " has passed");
                CUR_YEAR++;
            }

            DoEnd.PrintEnd();

        }
    }
}