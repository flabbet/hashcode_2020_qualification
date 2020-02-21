using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google_Hash_Code
{
    public class ProblemSolver
    {

        public FileParser Data;
        public int LibrariesAmount;
        public List<Library> FinalLibraries;


        public ProblemSolver(FileParser data)
        {
            Data = data;
        }

        public void Solve()
        {
            Library shortestRegisterTimeLibrary = Data.Libraries.First(x => x.SignupProcessTime 
                                                                            == Data.Libraries.Min(y => y.SignupProcessTime));
            List<Library> librariesByPoints = Data.Libraries;
            librariesByPoints.Remove(shortestRegisterTimeLibrary);
            librariesByPoints.ForEach(x=> x.Points = CalculateBooksPoints(x) * x.ShippingCapacityPerDay - 
                                                     x.SignupProcessTime - CalculateDuplicateBooksPoints(shortestRegisterTimeLibrary, x));
            librariesByPoints = librariesByPoints.OrderByDescending(x=> x.Points).ToList();
            LibrariesAmount = CalculateLibrariesAmount(shortestRegisterTimeLibrary, librariesByPoints);
            librariesByPoints.ForEach(x=> x.Books = x.Books.OrderByDescending(y=> y.Score).ToList());
            FinalLibraries = new List<Library>();
            FinalLibraries.Add(shortestRegisterTimeLibrary);
            for (int i = 0; i < LibrariesAmount - 1; i++)
            {
                FinalLibraries.Add(librariesByPoints[i]);
            }
        }

        private int CalculateLibrariesAmount(Library shortestLibrary, List<Library> libraries)
        {
            int timeLeft = Data.Deadline - shortestLibrary.SignupProcessTime;
            int librariesAmount = 1;
            int i = 0;
            while (timeLeft > 0)
            {
                if (i > libraries.Count - 1) return librariesAmount;
                if (timeLeft - libraries[i].SignupProcessTime < 0)
                {
                    return librariesAmount;
                }

                timeLeft -= libraries[i].SignupProcessTime;
                librariesAmount++;
                i++;
            }

            return librariesAmount;
        }

        private int CalculateBooksPoints(Library library)
        {
            return library.Books.Sum(x => x.Score);
        }

        private int CalculateDuplicateBooksPoints(Library sourceLibrary, Library targetLibrary)
        {
            List<Book> duplicates = sourceLibrary.Books;
            duplicates = duplicates.Concat(targetLibrary.Books).ToList();

            var dups = duplicates.GroupBy(x => x.Score)
                .Where(g => g.Count() > 1)
                .Select(g => g.Key)
                .ToList();
            return dups.Sum();
        }
    }
}
