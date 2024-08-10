using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatikaIMBDTask
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ▼ Creating list of 'Movie' with name and Imdb score property defined in Movie class ▼
            List<Movie> movieList = new List<Movie>();

            // ▼ According to user yes answer getting movies from user with while loop ▼
            bool repeatingCheck = true; // -> Its the key of while loop repeating
            while (repeatingCheck)
            {
                Movie movie = CreatingMovie(); // -> This is a method where I define below for creating 'Movie' with taking name and IMDB score.
                movieList.Add(movie); // -> Adding 'Movie' created by user to Movie Generic List - List<Movie>

                // ▼ Part of asking adding another movie ▼
                Console.WriteLine("Do you want add more movie?:(Yes/No)");
                string repeatingAnswer = Console.ReadLine().ToLower();
                if (repeatingAnswer != "yes")
                { repeatingCheck = false; } // -> go to loop while
            }

            DisplayAllMovies(movieList); // -> Its the method where I define below. Displaying all movies from Parameter:List<Movie> 

            GetMovieBetweenScores(movieList, 4, 9); // -> Its the method where I define below. Parameter:List<Movie>, first range for filtering score, second range for filtering score. In task instruction these range between 4 and 9

            GetMovieStartingWith(movieList, "A"); // -> Its the method where I define below. Parameter:List<Movie>, Letter for filtering starting with. In task instruction starting with 'A'.
        }

        // ▼ Its the method of creating 'Movie' with using another getmoviename and getimdbscore methods.
        static Movie CreatingMovie()
        {
            Movie movie = new Movie();
            movie.Name = GetMovieName();
            movie.ImdbScore = GetIMDBScore();
            return movie;
        }

        // ▼ Taking Movie Name from user as text ▼
        static string GetMovieName()
        {
            Console.Write("Please write a name of movie:");
            string movieName = Console.ReadLine();
            string movieNameEdited = char.ToUpper(movieName[0]) + movieName.Substring(1); // -> Making first letter capitalize
            return movieNameEdited;
        }

        // ▼ Taking Movie Score from user as double ▼
        static double GetIMDBScore()
        {
            bool formatCheck = false;
            double scoreIMDB = 0;
            while (!formatCheck) // -> Its the bool key for formatcheck
            {
                try // -> If format is true formatcheck is okay and end of loop
                {
                    Console.Write("Please write a score of IMDB:");
                    scoreIMDB = Convert.ToDouble(Console.ReadLine());
                    formatCheck = true;
                }
                catch (FormatException fe) // -> If format mistake message of formatexception
                {
                    Console.WriteLine(fe.Message);
                }
            }
            return scoreIMDB;
        }

        // ▼ Displaying all 'Movie' in defining List<Movie> as parameter ▼
        static void DisplayAllMovies(List<Movie> movieList)
        {
            Console.WriteLine("▼ All film you added ▼");
            foreach (Movie movie in movieList)
            {
                Console.WriteLine($"Name  -> {movie.Name}, IMBD Score -> {movie.ImdbScore}");

            }
            Console.WriteLine("*******************************************");
        }

        // ▼ Displaying 'Movies' in defining List<Movie> as parameter and score ranges ▼
        static void GetMovieBetweenScores(List<Movie> movieList, double firstScore, double secondScore)
        {
            Console.WriteLine($"▼ Films are that IMBD score between {firstScore} and {secondScore} ▼");
            List<Movie> moviesBetweenScores = movieList.Where(movie => movie.ImdbScore >= firstScore && movie.ImdbScore <= secondScore).ToList();
            if (moviesBetweenScores.Count > 0)
            {
                foreach (Movie movie in moviesBetweenScores)
                {
                    Console.WriteLine("Name -> " + movie.Name + " IMDB Score -> " + movie.ImdbScore);
                }
            }
            else { Console.WriteLine("There is no film you added that IMBD score between 4-9 ..."); }
            Console.WriteLine("*******************************************");
        }

        // ▼ Displaying 'Movies' in defining List<Movie> as parameter and first letter parameter ▼
        static void GetMovieStartingWith(List<Movie> movieList, string letter)
        {
            Console.WriteLine($"▼ Films are starting names with {letter} ▼");
            List<Movie> moviesStartingA = movieList.Where(movie => movie.Name.StartsWith(letter)).ToList();
            if (moviesStartingA.Count > 0)
            {
                foreach (Movie movie in moviesStartingA)
                {
                    Console.WriteLine("Name -> " + movie.Name + " IMDB Score -> " + movie.ImdbScore);
                }
            }
            else { Console.WriteLine($"There is no film you added that starting with {letter} ..."); }
        }

    }
}
