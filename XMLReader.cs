using Bunnies;
using bunnys_hill;
using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLWork
{
    class XMLReader
    {
        static XmlDocument xDoc = new XmlDocument();

        static List<Bunny> initialBunnies = new List<Bunny>();

        #region Converter
        /// <summary>
        /// This function converts bunnies from XML file to list type of Bunny
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static List<Bunny> ConvertXmlToList(string path)
        {
            try
            {
                xDoc.Load(path);
            }
            catch
            {
                initialBunnies = Logic.GenerateInitialBunnies(5);
                return initialBunnies;
            }

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                Bunny selectedBunny = ParseSingleBunny(xnode);
                initialBunnies.Add(selectedBunny);
            }
            return initialBunnies;
        }
        #endregion

        #region HelpFunctions

        /// <summary>
        /// Converts one bunny from XML Node to object type of Bunny
        /// </summary>
        /// <param name="xnode"></param>
        /// <returns></returns>
        private static Bunny ParseSingleBunny(XmlNode xnode)
        {
            Sex selectedSex = 0;//sex of bunny
            Color selectedColor = 0;//color of bunny
            int selectedAge = 0;//age of bunny
            string selectedName;//name of bunny

            XmlNode mainAttr = xnode.Attributes.GetNamedItem("Name");
            selectedName = mainAttr.Value;

            foreach (XmlNode childAttr in xnode.Attributes)
            {
                if (childAttr.Name == "Sex")
                {
                    Enum.TryParse(childAttr.InnerText, out selectedSex);
                }

                if (childAttr.Name == "Age")
                {
                    Int32.TryParse(childAttr.InnerText, out selectedAge);
                }

                if (childAttr.Name == "Color")
                {
                    Enum.TryParse(childAttr.InnerText, out selectedColor);
                }
            }

            return new Bunny(selectedName, (int)selectedSex, (int)selectedColor, selectedAge);
        }
        #endregion
    }
}
