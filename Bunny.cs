using System;

namespace bunnys_hill
{
    /// <summary>
    /// Our bunny in the watership.
    /// </summary>
    public class Bunny
    {
        public const int InitialAge = 0;//minimum age of bunny
        public const int MAX_AGE = 10;//maximum age of bunny
        public const int ADULT_AGE = 2;//from 2 - 10 bunny is adult and ready to care the kids
        public const int MAX_VAMPIRE_AGE = 50;//maximum age of vampire bunny

        #region Properties

        private int _age = 0;//bunny's age (0-10 (if vampire - 0-50))
        private bool _is_radioactive_muatant_vampire_bunny;//radioactive mutant vampire bunny or not

        /// <summary>
        /// bunny's gender (male or female)
        /// </summary>
        public Sex Sex { get; private set; }

        /// <summary>
        /// bunny's color (white, black, brown, spotted)
        /// </summary>
        public Color Color { get; private set; }

        /// <summary>
        /// //bunny's age
        /// </summary>
        public int Age 
        {
            get
            {
                return _age;
            }
            set
            {
                AgeTests(value);
                _age = value;
            }
        }

        /// <summary>
        /// bunny's name
        /// </summary>
        public string Name { get; private set; } 

        /// <summary>
        /// adult bunny or not
        /// </summary>
        public bool isAdult { get; private set; }

        /// <summary>
        /// should the bunny die this year or not
        /// </summary>
        public bool isOld { get; private set; }

        /// <summary>
        /// radioactive bunny or not
        /// </summary>
        public bool isRadioactiveMutantVampireBunny
        {
            get
            {
                return _is_radioactive_muatant_vampire_bunny;
            }
            set
            {
                RadioactiveMutantVampireTest();
                _is_radioactive_muatant_vampire_bunny = value;
            }
        }

        #endregion

        #region Ctor

        /// <summary>
        /// Constructor of bunny.
        /// </summary>
        /// <param name="m_pSex"></param>
        /// <param name="m_pColor"></param>
        /// <param name="m_pAge"></param>
        public Bunny(string name, int sex, int color, int age)
        {
            Sex = (Sex)sex;
            Color = (Color)color;
            Age = age;
            Name = name;

            DoRadioactiveMutantVampire();
        }
        #endregion

        #region Tests
        /// <summary>
        /// this function checks the state of the bunny when its age changes
        /// </summary>
        /// <param name="value"></param>
        private void AgeTests(int value)
        {
            if (value >= MAX_AGE && isRadioactiveMutantVampireBunny != true) //if a regular bunny turns 10, he will die
            {
                value = MAX_AGE;
                isOld = true;
            }else if (value >= MAX_VAMPIRE_AGE && isRadioactiveMutantVampireBunny == true)//if a vampire bunny turns 50, he will die
            {
                value = MAX_VAMPIRE_AGE;
                isOld = true;
            }

            if (value < InitialAge)
            {
                value = InitialAge;
            }

            if (value >= ADULT_AGE)// if the age of the bunny is more than 2, then he is an adult
            {
                isAdult = true;
            }
        }

        /// <summary>
        /// if a bunny becomes a vampire, which is old, then he immediately ceases to be such
        /// </summary>
        private void RadioactiveMutantVampireTest()
        {
            //there is no need to check how the status of the bunny has changed (to a vampire or not), so you can become a vampire, but not vice versa
            if (isOld == true)
            {
                isOld = false;
            }
        }
        #endregion

        #region RadioactiveMutantVampireBunnies
        /// <summary>
        /// there is a 2% chance that a rabbit will be born with a vampire mutation
        /// then its maximum age is 50 years
        /// also every year he bites another regular bunny, and turns him into a vampire
        /// </summary>
        private void DoRadioactiveMutantVampire()
        {
            Random random = new Random();

            int rNum = random.Next(101);

            if (rNum < 2)
            {
                isRadioactiveMutantVampireBunny = true;
            }
        }
        #endregion
    }
}