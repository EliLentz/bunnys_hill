using bunnys_hill;
using Integerator;
using System.Collections.Generic;

namespace Bunnies
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Bunny> bunnies;//creating initial bunnies

            //bunnies = Logic.GenerateInitialBunnies(5); //giving random features (color and gender)for the bunnies

            string xmlFile = "InitailBunnies.xml"; //file's URL address

            bunnies = IntegeratorXml.ConvertXmlToList(xmlFile);

            Hill.Hill hill = new Hill.Hill(bunnies); //starting the circly of bunny's life
        }
    }
}