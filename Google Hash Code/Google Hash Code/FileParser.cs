using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Win32;

namespace Google_Hash_Code
{
    public class FileParser
    {
        public string FileName;

        public int AmountOfBooks;
        public int AmountOfLibraries;
        public int Deadline;

        public int[] ScoresOfBooks;
        public List<Library> Libraries;

        public FileParser(string fileName)
        {
            FileName = fileName;
        }

        public void Parse()
        {
            string[] lines = RemoveEmptyLines(File.ReadAllText(FileName).Split('\n'));
            string[] scanData = lines[0].Split(' ');
            AmountOfBooks = int.Parse(scanData[0]);
            AmountOfLibraries = int.Parse(scanData[1]);
            Deadline = int.Parse(scanData[2]);

            ScoresOfBooks = ReadScores(lines[1]);

            Libraries = ReadLibraries(lines).ToList();
        }

        private string[] RemoveEmptyLines(string[] lines)
        {
            List<string> linesList = lines.ToList();
            if (linesList[lines.Length - 1].Length == 0)
            {
                linesList.RemoveAt(linesList.Count - 1);
                return RemoveEmptyLines(linesList.ToArray());
            }
            else
            {
                return linesList.ToArray();
            }
        }

        private Library[] ReadLibraries(string[] lines)
        {
            List<Library> libraries = new List<Library>();
            var linesList = lines.ToList();
            linesList.RemoveAt(0);
            linesList.RemoveAt(0);
            lines = linesList.ToArray();
            for (int i = 0; i < lines.Length; i+=2)
            {
                string[] libraryData = lines[i].Split(' ');
                libraries.Add(
                    new Library(int.Parse(libraryData[0]), 
                    int.Parse(libraryData[1]), int.Parse(libraryData[2])));
                libraries.Last().Books = ReadBooks(lines[i + 1]);
                libraries.Last().Id = libraries.Count - 1;
            }

            return libraries.ToArray();
        }

        private List<Book> ReadBooks(string line)
        {
            List<Book> books = new List<Book>();
            string[] rawBookIds = line.Split(' ');
            for (int i = 0; i < rawBookIds.Length; i++)
            {
                int id = int.Parse(rawBookIds[i]);
                books.Add(new Book(id, ScoresOfBooks[id]));
            }

            return books;
        }

        private int[] ReadScores(string line)
        {
            string[] rawScores = line.Split(' ');
            int[] scores = new int[rawScores.Length];

            for (int i = 0; i < scores.Length; i++)
            {
                scores[i] = int.Parse(rawScores[i]);
            }

            return scores;
        }
    }
}
