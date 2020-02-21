using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Hash_Code
{
    public class SolutionBuilder
    {
        public ProblemSolver Solver;
        public string InputFile;

        public SolutionBuilder(ProblemSolver solver, string inputFile)
        {
            Solver = solver;
            InputFile = inputFile;
        }

        public void BuildOutputFile()
        {
            string content = "";
            content += $"{Solver.LibrariesAmount}\n";
            foreach (var library in Solver.FinalLibraries)
            {
                content += $"{library.Id} {library.AmountOfBooks}\n";
                foreach (var book in library.Books)
                {
                    content += $"{book.Id} ";
                }

                content += "\n";
            }

            File.WriteAllText($"{InputFile}-output.txt", content);
        }
    }
}
