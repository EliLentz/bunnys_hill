using bunnys_hill;
using Hill;
using System;

namespace Bunnies
{
    public class Logic
    {
        public const int MAX_AGE = 10;//maximum age of bunny
        public const int ADULT_AGE = 2;//from 2 - 10 bunny is adult and ready to care the kids
        const int InitialAge = 0;

        /// <summary>
        /// A method for generating random bunnies.
        /// </summary>
        /// <param name="numberOfBunnies"> How many bunnies to generate</param>
        /// <returns> An array of the generated bunnies </returns>
        public static Bunny[] GenerateRandomBunnies(int numberOfBunnies)
        {
            Bunny[] bunny_arr = new Bunny[numberOfBunnies];

            Random random = new Random();
            for (int i = 0; i < numberOfBunnies; i++)
            {
                int generatedSex = random.Next(Enum.GetNames(typeof(Sex)).Length);
                int generatedColor = random.Next(Enum.GetNames(typeof(Color)).Length);

                Console.Write("Please, Enter " + (Sex)generatedSex + " Bunny's name: ");

                string givenName = Console.ReadLine();

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, InitialAge);

                bunny_arr[i] = generatedBunny;
            }

            return bunny_arr;
        }

        /// <summary>
        /// A method for generating random bunnies, but with initial genders.
        /// </summary>
        /// <param name="initialNumberOfBunnies"></param>
        /// <returns>An array of the generated bunnies</returns>
        public static Bunny[] GenerateInitialBunnies(int initialNumberOfBunnies)
        {
            Bunny[] bunny_arr = new Bunny[initialNumberOfBunnies];

            Random random = new Random();

            for (int i = 0; i < initialNumberOfBunnies; i++)
            {
                int generatedSex;
                if (i % 2 == 0)//
                {
                    generatedSex = (int)Sex.female;
                }
                else
                {
                    generatedSex = (int)Sex.male;
                }
                int generatedColor = random.Next(Enum.GetNames(typeof(Color)).Length);

                Console.Write("Please, Enter " + (Sex)generatedSex + " Bunny's name: ");

                string givenName = Console.ReadLine();

                Bunny generatedBunny = new Bunny(givenName, generatedSex, generatedColor, InitialAge);

                bunny_arr[i] = generatedBunny;
            }

            return bunny_arr;
        }
    }

    #region CircleOfBunnysLife

    public class StartCircle
    {
        const int MAX_YEAR = 1000; // max year is 1000 (starts from 0)
        public static int CUR_YEAR { get; private set; } //current year (starts from 0)

        static Hill<Bunny> hill = new Hill<Bunny>(); // thhe list of bunnys

        /// <summary>
        /// the constructor that starts the "loop"
        /// </summary>
        /// <param name="bunnies">For start circle, constructor need minimum 2 bunnies(male and female)</param>
        public StartCircle(Bunny[]bunnies)
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
                    hill.Reset();
                    ex_sex = hill.m_pCurrent.Data.Sex;
                    ex_color = hill.m_pCurrent.Data.Color;
                    ex_age = hill.m_pCurrent.Data.Age;
                    ex_name = hill.m_pCurrent.Data.Name;

                    if (ex_age >= Logic.ADULT_AGE)//adulthood test
                    {
                        if (ex_sex == Sex.female)
                        {
                            count_adult_female++;
                        }
                        else
                        {
                            count_adult_male++;
                        }
                    }

                    if (ex_age == Logic.MAX_AGE)//if the rabbit turns 11, he dies
                    {
                        hill.EraseNode();
                        Console.WriteLine(ex_name + " died");
                    }
                    else
                    {
                        ex_age++;

                        Bunny ex_bunny = new Bunny(ex_name, (int)ex_sex, (int)ex_color, ex_age);
                        hill.PushBack(ex_bunny);
                        hill.EraseNode();
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
        public static void PrintNewBunnies()
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
    }
    #endregion
}