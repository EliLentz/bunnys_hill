namespace bunnys_hill
{
    /// <summary>
    /// Our bunny in the watership.
    /// </summary>
    public class Bunny
    {

        #region Properties

        public Sex Sex { get; private set; } //bunny's gender (male or female)

        public Color Color { get; private set; } //bunny's color (white, black, brown, spotted)

        public int Age { get; private set; } //bunny's age (0 - 10)

        public string Name { get; private set; } //bunny's name

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