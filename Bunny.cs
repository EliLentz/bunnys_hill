namespace bunnys_hill
{
    /// <summary>
    /// Our bunny in the watership.
    /// </summary>
    public class Bunny
    {

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
                #region Tests
                if (value >= 10)
                {
                    value = 10;
                    Old = true;
                }else if (value < 0)
                {
                    value = 0;
                }
                if (value >= 2)
                {
                    Adult = true;
                }
                #endregion
                _age = value;
            }
        }

        public string Name { get; private set; } //bunny's name

        public bool Adult { get;private set; }// if the age of the bunny is more than 2, then he is an adult

        public bool Old { get; private set; }//how old is this bunny (if the bunny turns 10, he will die)

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
    }
}