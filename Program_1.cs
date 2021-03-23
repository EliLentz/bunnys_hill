using System;
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
                                        //without custom info
            Console.Write("Please, enter bunny's name: ");
            bunny1.setName();//enter a name
            bunny1.getValues(); //here we are getting info about it

            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
