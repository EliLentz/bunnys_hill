using bunnys_hill;
using System.Collections.Generic;
using XMLWork;

namespace Bunnies
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Bunny> bunnies;//creating initial bunnies

            const string FILE_NAME = "InitailBunnies.xml"; //file's URL address

            bunnies = XMLReader.ConvertXmlToList(FILE_NAME);

            Hill.Hill hill = new Hill.Hill(bunnies); //starting the circly of bunny's life
        }
    }
}