using System;
using System.Collections.Generic;
using System.IO;
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
            SaveDocument();
            Console.WriteLine("COMPLETED!");
        }

        private static void Initialize()
        {
            xmlDoc = new XmlDocument();
            keyValuePairs = new Dictionary<int, string>();
            xmlDoc.Load(AppConstant.FilePath);
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
                XmlElement node = xmlDoc.SelectSingleNode("//*[@id='" + item.Key + "']") as XmlElement;
                if (node != null) node.InnerText = item.Value;
                else throw new Exception("Node/Element " + item.Key + "Not Found");
            }
        }

        private static void SaveDocument()
        {
            xmlDoc.Save(AppConstant.FilePath);
        }
    }
}
