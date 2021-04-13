using Bunnies;
using bunnys_hill;
using System;
using System.Collections.Generic;
using System.Xml;

namespace Integerator
{
    class IntegeratorXml
    {
        static XmlDocument xDoc = new XmlDocument();

        static List<Bunny> initialBunnies = new List<Bunny>();

        #region Converter
        /// <summary>
        /// This function converts bunnies from XML file to list type of Bunny
        /// </summary>
        /// <param name="link"></param>
        /// <returns></returns>
        public static List<Bunny> ConvertXmlToList(string link)
        {
            int[] dataBunny = new int[3];//0 - Sex; 1 - Color; 2 - Age

            string selectedName;//name of bunny

            xDoc.Load(link);

            XmlElement xRoot = xDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                XmlNode mainAttr = xnode.Attributes.GetNamedItem("Name");
                selectedName = mainAttr.Value;

                dataBunny = SearcherLong(xnode);
                dataBunny = SearcherShort(xnode);

                Bunny selectedBunny = new Bunny(selectedName, dataBunny[0], dataBunny[1], dataBunny[2]);
                initialBunnies.Add(selectedBunny);
            }

            Logic.PrintNewBunnies(initialBunnies);
            return initialBunnies;
        }
        #endregion

        #region HelpFunctions

        /// <summary>
        /// this function searching attributs if they are written in long form
        /// </summary>
        /// <param name="xnode"></param>
        /// <returns></returns>
        private static int[] SearcherLong(XmlNode xnode)
        {
            int[] attrs = new int[3];

            foreach (XmlNode childNode in xnode.ChildNodes)
            {
                if (childNode.Name == "Sex")
                {
                    attrs[0] = (int)Enum.Parse(typeof(Sex), childNode.InnerText);
                }

                if (childNode.Name == "Age")
                {
                    attrs[2] = Int32.Parse(childNode.InnerText);
                }

                if (childNode.Name == "Color")
                {
                    attrs[1] = (int)Enum.Parse(typeof(Color), childNode.InnerText);
                }
            }

            return attrs;
        }

        /// <summary>
        /// this function searching attributs if they are written in short form
        /// </summary>
        /// <param name="xnode"></param>
        /// <returns></returns>
        private static int[] SearcherShort(XmlNode xnode)
        {
            int[] attrs = new int[3];

            foreach (XmlNode childAttr in xnode.Attributes)
            {
                if (childAttr.Name == "Sex")
                {
                    attrs[0] = (int)Enum.Parse(typeof(Sex), childAttr.InnerText);
                }

                if (childAttr.Name == "Age")
                {
                    attrs[2] = Int32.Parse(childAttr.InnerText);
                }

                if (childAttr.Name == "Color")
                {
                    attrs[1] = (int)Enum.Parse(typeof(Color), childAttr.InnerText);
                }
            }

            return attrs;
        }
        #endregion
    }
}
