using Bunnies;
using bunnys_hill;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Hill
{
    /// <summary>
    /// here we will use a list to save and control all the bunnies
    /// </summary>
    class Hill
    {
        List<Bunny> _hill = new List<Bunny>();// the list of bunnys
        List<Color> _f_color = new List<Color>();//list of adult female colors

        public static int CUR_YEAR { get; private set; } //current year (starts from 0)

        private int count_deadBunny = 0;//how many bunnies were died

        /// <summary>
        /// the constructor that starts the "loop"
        /// </summary>
        /// <param name="bunnies">For start circle, constructor needs minimum 2 bunnies(male and female)</param>
        public Hill(Bunny[] bunnies)
        {
            int count_adult_female;//how many adult female bunny's on the hill
            int count_adult_male;//how many adult male bunny's on the hill

            for (int i = 0; i < bunnies.Length; i++)//circle begins from inital bunny's
            {
                _hill.Add(bunnies[i]);
            }

            while (_hill.Count != 0)//circle in endless rage
            {
                IEnumerator<Bunny> _hill_enum = _hill.GetEnumerator();

                _hill_enum.Reset();
                _hill_enum.MoveNext();
                _f_color.Clear();

                count_adult_female = 0;
                count_adult_male = 0;

                foreach (Bunny bunny in _hill.ToList())
                {
                    if (bunny.isOld)//old age test
                    {
                        Console.WriteLine(bunny.Name + " died");
                        _hill.Remove(bunny);
                        count_deadBunny++;
                    }
                    else
                    {
                        if (bunny.isAdult)//adulthood test
                        {
                            if (bunny.Sex == Sex.female)
                            {
                                count_adult_female++;
                                _f_color.Add(_hill_enum.Current.Color);
                            }
                            else
                            {
                                count_adult_male++;
                            }
                        }
                        bunny.Age++;
                    }
                }

                IEnumerator<Color> _f_color_enum = _f_color.GetEnumerator();

                if (count_adult_female >= 1 && count_adult_male >= 1)//new bunnies are created here
                {
                    Color[] fColor_arr = new Color[count_adult_female];//array of adult female colors

                    _f_color_enum.Reset();
                    for (int i = 0; i < count_adult_female; i++)//filling the array by list for function "GenerateRandomBunnies()"
                    {
                        fColor_arr[i] = _f_color_enum.Current;
                        _f_color_enum.MoveNext();
                    }
                    Bunny[] new_bunnies = Logic.GenerateRandomBunnies(count_adult_female, count_adult_male, fColor_arr);
                    for (int i = 0; i < new_bunnies.Length; i++)
                    {
                        _hill.Add(new_bunnies[i]);
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