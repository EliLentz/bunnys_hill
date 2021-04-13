using Bunnies;
using bunnys_hill;
using System;
using System.Collections.Generic;

namespace Hill
{
    /// <summary>
    /// here we will use a list to save and control all the bunnies
    /// </summary>
    class Hill
    {
        List<Bunny> _hill = new List<Bunny>();// the list of bunnys
        public static int CUR_YEAR { get; private set; } //current year (starts from 0)

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

            TheCycleOfLife();
        }
        #endregion

        /// <summary>
        /// this method starts the life cycle of bunnies
        /// </summary>
        private void TheCycleOfLife()
        {
            while (_hill.Count != 0)//circle in endless rage
            {
                Logic.KillOldBunnies(_hill);
                List<Bunny> newBunnies = Logic.GenerateRandomBunnies(_hill);
                foreach (Bunny bunny in newBunnies)
                {
                    _hill.Add(bunny);
                }

                Logic.AddYearToBunnies(_hill);

                Console.WriteLine("Born: " + Logic.countNewBunnies + "\nDied: " + Logic.countDeadBunnies);

                Logic.countDeadBunnies = 0;
                Logic.countNewBunnies = 0;

                Console.ReadKey(); //tap to pass the year
                Console.WriteLine("Year " + CUR_YEAR + " has passed");
                CUR_YEAR++;
            }
        }
    }
}