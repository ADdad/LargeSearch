using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LargeSearchInfo.Core
{
    class Dictionary
    {
        const int MaxSize = 1000;
        FileSystem fileSystem = new FileSystem();
        List<Token> tokens = new List<Token>();

        public void AddWord(string word, int book)
        {
            if (tokens.Count >= MaxSize)
                ClearAndWriteResults();

            Token token = tokens.Find(x => x.Word.Equals(word));

            if (token == null)
                tokens.Add(new Token(word, book));
            else
                token.SetBook = book;
        }

        public void ClearAndWriteResults()
        {
            StreamWriter writer = new StreamWriter(fileSystem.GetPathToBlockNewFile());

            tokens.Sort();

            foreach (Token token in tokens)
                writer.WriteLine(token.ToString());

            writer.Close();
            tokens.Clear();
        }
    }
}
