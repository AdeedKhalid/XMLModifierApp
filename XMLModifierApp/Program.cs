using System;
using System.Collections.Generic;
using System.Xml;

namespace XMLModifierApp
{
    class Program
    {
        static XmlDocument xmlDoc = null;
        static Dictionary<int, string> keyValuePairs;

        static void Main(string[] args)
        {
            Initialize();
            LoadData();
            PerformXMLDataManupulation(keyValuePairs);
            RemoveMetaTagAttributesFromXML();
            SaveDocument();
            Console.WriteLine("COMPLETED!");
        }

        private static void Initialize()
        {
            xmlDoc = new XmlDocument();
            xmlDoc.Load(AppConstant.FilePath);
            keyValuePairs = new Dictionary<int, string>();
        }

        private static void LoadData()
        {
            keyValuePairs.Add(501, "Value1");
            keyValuePairs.Add(502, "Value2");
            keyValuePairs.Add(503, "Value3");
            keyValuePairs.Add(504, "Value4");
        }

        private static void PerformXMLDataManupulation(Dictionary<int, string> keyValuePairs)
        {
            foreach (var item in keyValuePairs)
            {
                XmlElement node = xmlDoc.SelectSingleNode("//*[@" + AppConstant.MetaTagName + "='" + item.Key + "']") as XmlElement;
                if (node != null) node.InnerText = item.Value;
                else throw new Exception("Node/Element " + item.Key + "Not Found.");
            }
        }

        private static void RemoveMetaTagAttributesFromXML()
        {
            XmlNodeList nodes = xmlDoc.SelectNodes("//*[@" + AppConstant.MetaTagName + "]");
            if (nodes == null) throw new Exception("No Element Found With MetaTag.");

            foreach (XmlNode node in nodes)
            {
                if (node.Attributes[AppConstant.MetaTagName] != null)
                    node.Attributes.Remove(node.Attributes[AppConstant.MetaTagName]);
            }
        }

        private static void SaveDocument()
        {
            xmlDoc.Save(AppConstant.FilePath);
        }
    }
}
