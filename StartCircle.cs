using Hill;
using bunnys_hill;
using System;

namespace Bunnies
{
    public class StartCircle
    {
        public static int CUR_YEAR { get; private set; } //current year (starts from 0)

        private int count_deadBunny = 0;//how many bunnies were died

        static Hill<Bunny> hill = new Hill<Bunny>(); // thhe list of bunnys

        /// <summary>
        /// the constructor that starts the "loop"
        /// </summary>
        /// <param name="bunnies">For start circle, constructor needs minimum 2 bunnies(male and female)</param>
        public StartCircle(Bunny[] bunnies)
        {
            int count_adult_female;//how many adult female bunny's on the hill
            int count_adult_male;//how many adult male bunny's on the hill

            int ex_count;//how many bunnies in list now

            for (int i = 0; i < bunnies.Length; i++)//circle begins from inital bunny's
            {
                hill.PushBack(bunnies[i]);
            }

            while (hill.count != 0)//circle in endless rage
            {
                hill.Reset();//starting the circle from begin

                count_adult_female = 0;
                count_adult_male = 0;

                ex_count = hill.count; //without it program doesn't work how it should work

                Hill<Color> fColor = new Hill<Color>();//list of adult female colors

                for (int i = 0; i < ex_count; i++)
                {
                    if (hill.m_pCurrent.Data.Old)//old age test
                    {
                        Console.WriteLine(hill.m_pCurrent.Data.Name + " died");
                        hill.EraseNode();
                        count_deadBunny++;
                    }
                    else
                    {
                        if (hill.m_pCurrent.Data.Adult)//adulthood test
                        {
                            if (hill.m_pCurrent.Data.Sex == Sex.female)
                            {
                                count_adult_female++;
                                fColor.PushBack(hill.m_pCurrent.Data.Color);
                            }
                            else
                            {
                                count_adult_male++;
                            }
                        }
                        hill.m_pCurrent.Data.Age++;

                        hill.MoveNext();
                    }
                }

                if (count_adult_female >= 1 && count_adult_male >= 1)//new bunnies are created here
                {
                    Color[] fColor_arr = new Color[count_adult_female];//array of adult female colors

                    fColor.Reset();
                    for (int i = 0; i < count_adult_female; i++)
                    {
                        fColor_arr[i] = fColor.m_pCurrent.Data;
                        fColor.MoveNext();
                    }
                    Bunny[] new_bunnies = Logic.GenerateRandomBunnies(count_adult_female ,fColor_arr);
                    for (int i = 0; i < new_bunnies.Length; i++)
                    {
                        hill.PushBack(new_bunnies[i]);
                    }
                }

                Console.WriteLine("Born: " + Logic.count_newBunny + "\nDied: " + count_deadBunny);

                count_deadBunny = 0;
                Logic.count_newBunny = 0;

                Console.ReadKey(); //tap to pass the year
                Console.WriteLine("Year " + CUR_YEAR + " has passed");
                CUR_YEAR++;
            }
        }
    }
}
