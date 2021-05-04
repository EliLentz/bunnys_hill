using Bunnies;
using bunnys_hill;
using End;
using NLog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hill
{
    /// <summary>
    /// here we will use a list to save and control all the bunnies
    /// </summary>
    class Hill
    {
        List<Bunny> _bunnies = new List<Bunny>();// the list of bunnys
        public static int CUR_YEAR { get; private set; } //current year (starts from 0)

        private static Logger logger = LogManager.GetCurrentClassLogger();

        #region Ctor
        /// <summary>
        /// the constructor that starts the "loop"
        /// </summary>
        /// <param name="bunnies">For start circle, constructor needs minimum 2 bunnies(male and female)</param>
        public Hill(List<Bunny> bunnies)
        {
            _bunnies = bunnies;
            Print.PrintNewBunnies(_bunnies);

            RunCycle();
        }
        #endregion

        #region RunCycle
        /// <summary>
        /// this method starts the life cycle of bunnies
        /// </summary>
        private void RunCycle()
        {
            while (!DoEnd.AreOnlyVampiresleft(_bunnies))//As long as there is at least one regular bunny, the program will keep working.
            {
                Task taskStopper = Times.Stopper();

                taskStopper.Start();

                if (_bunnies.Count > 500)//if the quantity of bunnies is more then 500, they will die by natural causes
                {
                    Logic.KillHalf(_bunnies);
                }

                Logic.KillOldBunnies(_bunnies);
                Logic.DoBite(_bunnies);
                List<Bunny> newBunnies = Logic.GenerateRandomBunnies(_bunnies);

                //adds new bunnies to list
                foreach (Bunny bunny in newBunnies)
                {
                    _bunnies.Add(bunny);
                }

                Logic.AddYearToBunnies(_bunnies);

                Print.PrintBunniesChangesOverTheYear(_bunnies);

                Times.RunTime();

                Print.PrintYearInfo(CUR_YEAR);
                CUR_YEAR++;
            }

            DoEnd.PrintEnd();

        }
        #endregion

    }
}