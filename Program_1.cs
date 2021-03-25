using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bunnys_hill
{
    class Program_1
    {
        private const int m_pBunnysQuan = 5; //how many bunnys we will create

        //auxiliary variables (original variables are in class @Bunny)
        private static int m_pSex; //male and female
        private static int m_pColor; //white, black, brown, spotted
        private static int m_pAge; //0 - 10
        private static string m_pName; //name of Bunny

        static Bunny[] GenerateRandomBunnies(int m_pBunnysQuan)//giving random features for new bunnies
        {
            Bunny [] bunny_arr = new Bunny[m_pBunnysQuan];

            Random random = new Random();

            //variables of maximum values
            const int m_pSexMax = 2; //male and female
            const int m_pColorMax = 4; //white, black, brown, spotted
            const int m_pAgeMax = 11; //0 - 10 (useless)

            for (int i = 0; i < m_pBunnysQuan; i++)
            {
                m_pSex = random.Next(m_pSexMax);
                m_pColor = random.Next(m_pColorMax);
                m_pAge = 0;

                Bunny bunny_ex = new Bunny(m_pSex, m_pColor, m_pAge);

                Console.Write("Please, Enter Bunny's name: ");
                m_pName = Console.ReadLine();
                bunny_ex.setName(m_pName);

                bunny_arr[i] = bunny_ex;
            }
            Console.WriteLine();

            return bunny_arr;
        }

        static void PrintBunnies(Bunny[] bunnies)
        {
            for (int i = 0; i < m_pBunnysQuan; i++)
            {
                Console.WriteLine(bunnies[i].getValues() + "\n");
            }
            
        }

        static void Main(string[] args)
        {
            Bunny[] bunnies;//creating bunnies

            bunnies = GenerateRandomBunnies(m_pBunnysQuan);//giving random features (color and gender)for the bunnies

            PrintBunnies(bunnies);//printing all info about bunny

            Console.ReadKey();
        }
    }
}