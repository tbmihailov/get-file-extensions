using System;
using System.IO;
using System.Collections.Generic;

namespace GetFileExtensions
{
    public class FileBrowser
    {
        public FileBrowser()
        {
        }

        private static List<string> extensionList;
        public static List<string> ExtensionList 
        {
            get
            {
                if (extensionList == null)
                {
                    extensionList = new List<string>();
                }
                return extensionList;
            }
            set
            {
                extensionList = value;
            }
        }

        public static void ProcessDir(string sourceDir, int recursionLvl)
        {

            DirectoryInfo di = new DirectoryInfo(sourceDir);
            var fileEntries = di.GetFiles();
            foreach (var file in fileEntries)
            {
                // do something with fileName
                ExtensionList.Add(file.Extension);
            }

            // Recurse into subdirectories of this directory.
            DirectoryInfo[] subdirEntries = di.GetDirectories();
            foreach (var subDir in subdirEntries)
                // Do not iterate through reparse points
                if ((File.GetAttributes(subDir.FullName) &
                     FileAttributes.ReparsePoint) !=
                         FileAttributes.ReparsePoint)

                    ProcessDir(subDir.FullName, recursionLvl + 1);
            //}
        }
    }
}