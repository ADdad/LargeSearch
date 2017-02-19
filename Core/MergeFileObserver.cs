using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LargeSearchInfo.Core
{
    class MergeFileObserver
    {
        private StreamReader file;
        private Token now;

        public Token GetToken
        {
            get { return now; }
        }

        public MergeFileObserver(string path)
        {
            file = new StreamReader(path);
        }

        public void ReadNextLine()
        {
            string line;
            if ((line = file.ReadLine()) != null)
                now = new Token(line);
            else
                now = null;
        }

        public bool HasNextLine()
        {
            return !file.EndOfStream;
        }

        public void CloseStream()
        {
            file.Close();
        }
    }
}
