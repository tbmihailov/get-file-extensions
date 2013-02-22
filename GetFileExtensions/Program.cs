using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CommandLine.Utility;
using System.IO;

namespace GetFileExtensions
{
    class Program
    {
        static void Main(string[] args)
        {
            Arguments arguments = new Arguments(args);
            string directoryName = "";//-directoryName:"d:\Acstre\AcstreControl\Source\AcsControl\"
            if (arguments["directoryName"] != null)
            {
                directoryName = arguments["directoryName"];
            }
            else
            {
                Console.WriteLine("Argument missing: \n -directoryName:\"SomeDir\"");
                return;
            }

            directoryName = Path.GetFullPath(directoryName);
            DirectoryInfo directory = new DirectoryInfo(directoryName);

            FileBrowser.ProcessDir(directory.FullName,1);
            var extensions = FileBrowser.ExtensionList.Distinct();


            foreach (var ext in extensions)
            {
                Console.Write(string.Format("*{0} ",ext));
            }
            

        }
    }
}
