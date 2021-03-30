using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunnys_hill
{
    /// <summary>
    /// Our bunny in the watership.
    /// </summary>
    public class Bunny
    {

        #region Properties

        /// <summary>
        /// TODO: comments above each property.
        /// </summary>
        public Sex Sex { get; private set; }

        public Color Color { get; private set; }

        public int Age { get; private set; }

        public string Name { get; private set; }

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