using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography;

namespace LargeSearchInfo.Core
{
    class FileSystem
    {
        public string PathToLibrary = @"E:\library";
        public string PathToResultDir = @"\resultsInfoSRC";

        public string[] GetFilesLibrary()
        {
            return Directory.GetFiles(PathToLibrary);
        }

        public void CreateDirForResults()
        {
            string path = Environment.CurrentDirectory + PathToResultDir;
            Directory.CreateDirectory(path);
            DirectoryInfo dir = new DirectoryInfo(path);

            foreach (FileInfo file in dir.GetFiles())
                file.Delete();
        }

        public string GenerateRandomTxtName()
        {
            return DateTime.Now.ToFileTime().ToString() + ".txt";
        }

        public string GetPathToBlockNewFile()
        {
            return Environment.CurrentDirectory + PathToResultDir + @"\" + GenerateRandomTxtName();
        }

        public string GetPathResultDir()
        {
            return Environment.CurrentDirectory + PathToResultDir;
        }

        public string[] GetBlockFiles()
        {
            return Directory.GetFiles(Environment.CurrentDirectory + PathToResultDir);
        }
    }
}
