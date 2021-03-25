using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunnys_hill
{
    public class Bunny
    {
        private Enums.Sex m_pSex = new Enums.Sex();
        private Enums.Color m_pColor = new Enums.Color();
        private int m_pAge; // 0 - 10
        private string m_pName; //name of Bunny

        public Bunny(int m_pSex, int m_pColor, int m_pAge) //constructor of bunny
        {
            this.m_pSex = (Enums.Sex)m_pSex;
            this.m_pColor = (Enums.Color)m_pColor;
            this.m_pAge = m_pAge;

            return;
        }

        public void setName(string m_pName)
        {
            this.m_pName = m_pName;
        }

        public string getValues()
        {
            Enums.Sex m_pSex = this.m_pSex;
            Enums.Color m_pColor = this.m_pColor;
            int m_pAge = this.m_pAge;
            string m_pName = this.m_pName;

            return "Bunny " + m_pName + " was burn. Features:\nGender: " + m_pSex + " Color: " + m_pColor + " Age: " + m_pAge; 
        }
    }
}
