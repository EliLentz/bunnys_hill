using System;
using System.Threading;
using System.Threading.Tasks;

namespace Bunnies
{
    public class Times
    {
        public static bool stopFlow = false;//Regulates flow

        public static void RunTime()
        {
            const int timeOfSleeping = 3000;//a constant indicating how long the program should wait to skip a year

            Thread.Sleep(timeOfSleeping);

            Task taskStopper = Stopper();
            taskStopper.Start();

            while (stopFlow)
            {
                if (taskStopper.Status.Equals(true))
                {
                    taskStopper.Dispose();
                }
            }
        }

        /// <summary>
        /// This function stops the loops and outputting data to the console
        /// and print about status of the flow
        /// </summary>
        /// <returns>Task of stopper</returns>
        public static Task Stopper()
        {
            Task taskStopper = new Task(() => {
                while (Console.ReadKey().Key != ConsoleKey.Enter) ;
                if (stopFlow == false)
                {
                    stopFlow = true;
                    Console.WriteLine("Console operations have stopped");
                }
                else
                {
                    stopFlow = false;
                    Console.WriteLine("Сonsole operations have resumed");
                }
            });
            return taskStopper;
        }

    }
}
