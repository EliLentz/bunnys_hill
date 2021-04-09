namespace bunnys_hill
{
    /// <summary>
    /// Our bunny in the watership.
    /// </summary>
    public class Bunny
    {
        public const int InitialAge = 0;
        public const int MAX_AGE = 10;//maximum age of bunny
        public const int ADULT_AGE = 2;//from 2 - 10 bunny is adult and ready to care the kids

        #region Properties

        private int _age = 0;//bunny's age (0 - 10)

        public Sex Sex { get; private set; } //bunny's gender (male or female)

        public Color Color { get; private set; } //bunny's color (white, black, brown, spotted)

        public int Age 
        {
            get
            {
                return _age;
            }
            set
            {
                Tests(value);
                _age = value;
            }
        }

        public string Name { get; private set; } //bunny's name

        public bool isAdult { get; set; }// if the age of the bunny is more than 2, then he is an adult

        public bool isOld { get; set; }//how old is this bunny (if the bunny turns 10, he will die)
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
        }
        #endregion

        #region Tests
        public void Tests(int value)
        {
            if (value >= MAX_AGE)
            {
                value = MAX_AGE;
                isOld = true;
            }
            else if (value < InitialAge)
            {
                value = InitialAge;
            }
            if (value >= ADULT_AGE)
            {
                isAdult = true;
            }
        }
        #endregion
    }
}