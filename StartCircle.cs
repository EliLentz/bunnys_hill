using Hill;
using bunnys_hill;
using System;

namespace Bunnies
{
    public class StartCircle
    {
        const int MAX_YEAR = 1000; // max year is 1000 (starts from 0)
        public static int CUR_YEAR { get; private set; } //current year (starts from 0)

        static Hill<Bunny> hill = new Hill<Bunny>(); // thhe list of bunnys

        /// <summary>
        /// the constructor that starts the "loop"
        /// </summary>
        /// <param name="bunnies">For start circle, constructor need minimum 2 bunnies(male and female)</param>
        public StartCircle(Bunny[] bunnies)
        {
            Sex ex_sex;//example of bunny's sex
            Color ex_color;//example of bunny's color
            int ex_age;//example of bunny's age
            string ex_name;//example of bunny's name

            int count_adult_female;//how many adult female bunny's on the hill
            int count_adult_male;//how many adult male bunny's on the hill

            int ex_count;//example of quantity of elements

            for (int i = 0; i < bunnies.Length; i++)//circle begins from inital bunny's
            {
                hill.PushBack(bunnies[i]);
            }

            for (int i = 0; i < MAX_YEAR; i++)//circle in rage 1000 years
            {
                count_adult_female = 0;
                count_adult_male = 0;

                ex_count = hill.count;

                for (int j = 0; j < ex_count; j++)
                {
                    hill.Reset();//starting the circle from begin

                    //here the variables take the values of the current bunny
                    ex_sex = hill.m_pCurrent.Data.Sex;
                    ex_color = hill.m_pCurrent.Data.Color;
                    ex_age = hill.m_pCurrent.Data.Age;
                    ex_name = hill.m_pCurrent.Data.Name;--

                    if (ex_sex == Sex.female)//adulthood test
                    {
                        count_adult_female += Convert.ToInt32(AdulthoodTest(ex_age));
                    }
                    else
                    {
                        count_adult_male += Convert.ToInt32(AdulthoodTest(ex_age));
                    }

                    if (OldTest(ex_age))//old age test
                    {
                        hill.EraseNode();
                        Console.WriteLine(ex_name + " died");
                    }
                    else
                    {
                        ex_age++;

                        Bunny ex_bunny = new Bunny(ex_name, (int)ex_sex, (int)ex_color, ex_age);//creating a new bunny, but with old features, except age (current age+ 1)
                        hill.PushBack(ex_bunny);//enter current bunny in the list to new node
                        hill.EraseNode();//and erase it from old node
                    }
                }

                if (count_adult_female > 1 && count_adult_male > 1)//new bunnies are created here
                {
                    Bunny[] new_bunnies = Logic.GenerateRandomBunnies(count_adult_female);
                    for (int j = 0; j < new_bunnies.Length; j++)
                    {
                        hill.PushBack(new_bunnies[j]);
                    }
                }

                Console.ReadKey(); //tap to pass the year
                Console.WriteLine("Year " + CUR_YEAR + " has passed");
                PrintNewBunnies();
                CUR_YEAR++;
            }
        }

        /// <summary>
        /// this method print the new bunnies, what were born this year
        /// </summary>
        private void PrintNewBunnies()
        {
            for (int i = 0; i < hill.count; i++)
            {
                if (hill.m_pCurrent.Data.Age == 0)
                {
                    Console.WriteLine("New Bunny " + hill.m_pCurrent.Data.Name + " was born. Color: " + (Color)hill.m_pCurrent.Data.Color + ", Sex: " + (Sex)hill.m_pCurrent.Data.Sex);
                }
                hill.MoveNext();
            }
        }

        /// <summary>
        /// this method tests whether the bunny is ready for offspring
        /// </summary>
        /// <param name="age"></param>
        /// <returns>adult(+1) or not(+0), but in boolean</returns>
        private bool AdulthoodTest(int age)
        {
            if (age >= Logic.ADULT_AGE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        //test: how old is this bunny (if the rabbit turns 11, he will die)
        /// </summary>
        /// <param name="age"></param>
        /// <returns>old(true) or not(false)</returns>
        private bool OldTest(int age)
        {
            if (age >= Logic.MAX_AGE)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
