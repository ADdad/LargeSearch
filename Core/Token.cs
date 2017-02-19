using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LargeSearchInfo.Core
{
    class Token : IEquatable<Token>, IComparable<Token>
    {
        private List<int> books = new List<int>();
        private string wd;

        public string Word
        {
            get { return wd; }
        }

        public string GetBooksString
        {
            get
            {
                string result = "";
                foreach (int book in books)
                {
                    result += book.ToString() + ",";
                }

                return result.Substring(0, result.Length - 1);
            }
        }

        public int SetBook
        {
            set
            {
                if (!books.Contains(value)) books.Add(value);
            }
        }

        public List<int> GetBooksList
        {
            get
            {
                return books;
            }
        }

        public Token(string word, int book)
        {
            wd = word;
            books.Add(book);
        }

        public Token(string line)
        {
            string[] result = line.Split('-');
            wd = result[0];
            string[] booksResult = result[1].Split(',');

            foreach(string book in booksResult)
                SetBook = int.Parse(book);
        }

        public void AddBooks(List<int> _books)
        {
            foreach(int book in _books)
                SetBook = book;
        }

        public override string ToString()
        {
            return wd + "-" + GetBooksString;
        }

        public int CompareTo(Token other)
        {
            return (other == null) ? 3 : Word.CompareTo(other.Word);
        }

        bool IEquatable<Token>.Equals(Token other)
        {
            return (other == null) ? false : Word.Equals(other.Word);
        }
    }
}
