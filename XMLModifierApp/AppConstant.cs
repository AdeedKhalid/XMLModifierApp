using System;
using System.IO;

namespace XMLModifierApp
{
    public static class AppConstant
    {
        public static string FileName = "XMLFileData.xml";
        public static string FilePath = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + "\\" + FileName;
    }
}
