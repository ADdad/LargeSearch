using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.IO;

namespace LargeSearchInfo.Core
{
    class Merge
    {
        MergeFileObserver firstObserver;
        MergeFileObserver secondObserver;
        FileSystem files = new FileSystem();
        StreamWriter writer;

        public Merge(string fisrt, string second)
        {
            firstObserver = new MergeFileObserver(fisrt);
            firstObserver.ReadNextLine();
            secondObserver = new MergeFileObserver(second);
            secondObserver.ReadNextLine();
            writer = new StreamWriter(files.GetPathToBlockNewFile());
        }

        public void Run()
        {
           while(firstObserver.HasNextLine() || firstObserver.GetToken != null)
            {
                int res = firstObserver.GetToken.CompareTo(secondObserver.GetToken);

                if(res == 0)
                {
                    foreach (var book in secondObserver.GetToken.GetBooksList)
                        firstObserver.GetToken.SetBook = book;
                    writer.WriteLine(firstObserver.GetToken.ToString());

                    firstObserver.ReadNextLine();
                    secondObserver.ReadNextLine();
                }
                else if(res == 1)
                {
                    writer.WriteLine(secondObserver.GetToken.ToString());
                    secondObserver.ReadNextLine();
                }
                else
                {
                    writer.WriteLine(firstObserver.GetToken.ToString());
                    firstObserver.ReadNextLine();
                }
            }

           while(secondObserver.HasNextLine() || secondObserver.GetToken != null)
            {
                writer.WriteLine(secondObserver.GetToken.ToString());
                secondObserver.ReadNextLine();
            }
            firstObserver.CloseStream();
            secondObserver.CloseStream();
            writer.Close();
        }
    }
}
