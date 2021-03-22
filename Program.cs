﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunnys_hill
{
    class Program
    {
        static void Main(string[] args)
        {
            Bunny bunny1 = new Bunny(); //here we are creating a one bunny
            bunny1.getValues(); //here we are getting info about it
            Console.ReadKey();
        }
    }

    class Bunny
    {
        private enum Sex { male, female }
        private enum Color { white, black, brown, spotted }

        private Sex m_pSex = new Sex();
        private Color m_pColor = new Color();
        private int m_pAge;
        private string m_pName;

        public Bunny()
        {
            Console.Write("Please, enter bunny's name: ");
            string m_pName = Convert.ToString(Console.ReadLine());

            Random random = new Random();
            int m_pSex = random.Next(0, 2);
            int m_pColor = random.Next(0, 4);
            int m_pAge = random.Next(0, 11);

            this.m_pName = m_pName;
            this.m_pSex = (Bunny.Sex)m_pSex;
            this.m_pColor = (Bunny.Color)m_pColor;
            this.m_pAge = m_pAge;

            return;
        }

        public void getValues()
        {
            Console.WriteLine("\nBunny " + this.m_pName + " was born!");
            Console.WriteLine("Age: " + this.m_pAge + "\nSex: " + this.m_pSex + "\nColor: " + this.m_pColor);
        }
    }
}
