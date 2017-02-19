using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace LargeSearchInfo.Core
{
    class Main
    {
        FileSystem FileSys = new FileSystem();
        Regex Regex = new Regex(@"[^a-zA-Z ]");
        string LineForParse;

        public void StartParse()
        {
            string[] library = FileSys.GetFilesLibrary();
//dklsajdl
          
        }

        public void StartMerge()
        {
            string[] blocks = FileSys.GetBlockFiles();
            for (int i = 0; i < blocks.Length; i += 2)
            {
                if (i < blocks.Length - 1)
                    Merge(blocks[i], blocks[i + 1]);
            }

            if (FileSys.GetBlockFiles().Length > 1)
                StartMerge();

        }

        private void Merge(string path1, string path2)
        {
            Console.WriteLine(path1);
            Console.WriteLine(path2);
            Merge merge = new Merge(path1, path2);
            merge.Run();
            File.Delete(path1);
            File.Delete(path2);
        }

        private void ParseBook(string path, int num)
        {
            StreamReader reader = new StreamReader(path);
            Dictionary dic = new Dictionary();

            while ((LineForParse = reader.ReadLine()) != null)
            {
                string[] words = Regex.Replace(LineForParse.ToLower(), "").Split(' ');

                foreach (string word in words)
                    dic.AddWord(word, num);
            }

            dic.ClearAndWriteResults();
            reader.Close();
        }
    }
}
