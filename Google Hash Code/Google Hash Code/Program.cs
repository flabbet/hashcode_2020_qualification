using System;

namespace Google_Hash_Code
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] fileNames = args;
            for (int i = 0; i < fileNames.Length; i++)
            {
                FileParser parser = new FileParser(fileNames[i]);
                parser.Parse();
                ProblemSolver solver = new ProblemSolver(parser);
                solver.Solve();
                SolutionBuilder builder = new SolutionBuilder(solver, fileNames[i]);
                builder.BuildOutputFile();
                Console.WriteLine("Done");
            }

            Console.ReadKey();
        }
    }
}
