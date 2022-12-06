using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Entertainment_App.Models
{
    public class Movie : Media
    {
        private string _fileName;
        private string Genres;
        private List<Movie> Movies = new();
        private MovieContext context = new MovieContext();
        private DateTime ReleaseDate;
        private string Title;

        public Movie()
        {
            var factory = LoggerFactory.Create(b => b.AddConsole());
            var logger = factory.CreateLogger<Program>();
            // uncomment to view logger
            //logger.LogInformation("Inside Movie  default constructor");
            //Console.WriteLine("movie object created");
        }
        public override void Delete()
        {
            Console.WriteLine("Enter the MovieId to delete");//ErrorEventArgs checking added to Delete method. Add method still not functioning.                                  
            var movieIdToDelete = Convert.ToInt32(Console.ReadLine());

            var MovieToRemove = context.Movies.FirstOrDefault(x => x.Id == movieIdToDelete);
            var confirm = false;

            if (MovieToRemove != null)
            {
                Console.WriteLine("Found " + MovieToRemove.Title + ", are you sure you want to remove it? Y/N");
                var confirmStr = Console.ReadLine().ToUpper();
                confirm = confirmStr == "Y" ? true : false;

            }
            else
            {
                Console.WriteLine("No movie by that ID found.");
                confirm = false;
            }

            if (confirm)
            {
                context.Remove(MovieToRemove);
                context.SaveChanges();

                Console.WriteLine("Movie was removed!");
            }
        }

        public override void Update()
        {
            Console.WriteLine("Enter the ID of the movie you would like to update:");
            var movieIdToUpdate = Convert.ToInt32(Console.ReadLine());

            var MovieToUpdate = context.Movies.FirstOrDefault(x => x.Id == movieIdToUpdate);

            // note that we are assuming the user wants to update the title - again not good
            Console.WriteLine($"Here is your movie {MovieToUpdate.Title}");

            Console.Write("Do you want to update the movie title? Type Y for yes: ");
            var answer = Console.ReadLine();

            if (answer == "Y" || answer == "y")
            {
                Console.WriteLine("What do you want to change title to?");
                var newTitle = Console.ReadLine();

                MovieToUpdate.Title = newTitle;
                context.Update(MovieToUpdate);
            }

            Console.WriteLine("Do you want to update the movie date? Type Y for yes: ");
            var answer2 = Console.ReadLine();

            if (answer2 == "Y" || answer2 == "y")
            {

                Console.WriteLine("Enter the updated release date MM/DD/YYYY:");
                var movieRelease = Console.ReadLine();
                var NewmovieReleaseDate = DateTime.Parse(movieRelease);

                MovieToUpdate.ReleaseDate = NewmovieReleaseDate;
                context.Update(MovieToUpdate);

            }

            context.SaveChanges();

            Console.WriteLine("You are done updating");
        }

        public override void Add()
        {
            // Add Movie To Database
            Console.WriteLine("Enter the movie title");
            var movieTitle = Console.ReadLine();

            Console.WriteLine("Enter the release date MM/DD/YYYY:");
            var movieRelease = Console.ReadLine();
            var movieReleaseDate = DateTime.Parse(movieRelease);

            var movie = new MovieLibraryEntities.Models.Movie()
            {
                Title = movieTitle,
                ReleaseDate = movieReleaseDate
            };

            //InvalidOperationException: The entity type 'Movie' was not found.
            //Ensure that the entity type has been added to the model.
            context.Add(movie);
            context.SaveChanges();
            Console.WriteLine("Movie was added!");

        }

        public override void Display()
        {
            var movies = context.Movies
                .Include(x => x.MovieGenres)
                .ThenInclude(x => x.Genre)
                .ToList();

            foreach (var movie in movies)
            {
                var genreString = string.Empty;
                foreach (var genre in movie?.MovieGenres ?? new List<MovieGenre>())
                {
                    if (genreString.Length == 0)
                    {
                        genreString += genre?.Genre?.Name;
                    }
                    else
                    {
                        genreString += ", " + genre?.Genre?.Name;
                    }
                }
                Console.Write("MovieID: " + movie.Id + " ");
                Console.WriteLine(movie.Title + " " + genreString);
            }
        }

        public override void Read()
        {
            _fileName = $"{Environment.CurrentDirectory}/Files/movies.csv";

            if (!File.Exists(_fileName))
            {
                Console.WriteLine($"File does not exist {_fileName}");
            }

            try
            {
                var sr = new StreamReader(_fileName);
                // first line contains column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {

                    var film = new Movie();

                    var line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in movie title
                    var idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in movie title
                        // movie details are separated with comma(,)

                        //String strDetails; 
                        var movieDetails = line.Split(',');
                        //strDetails  = (String) movieDetails;
                        //Console.WriteLine(strDetails);

                        // 1st array element contains movie id
                        film.Id = int.Parse(movieDetails[0]);
                        // 2nd array element contains movie title
                        film.Title = movieDetails[1];
                        // 3rd array element contains movie genre(s)
                        // replace "|" with ", "
                        film.Genres = movieDetails[2].Replace("|", ", ");
                        // Add Film to Movie List
                        //Movies.Add(film);
                    }
                    else
                    {
                        // quote = comma in movie title
                        // extract the 
                        film.Id = int.Parse(line.Substring(0, idx - 1));
                        // remove movieId and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the e
                        film.Title = line.Substring(0, idx);
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                        // replace the "|" with ", "
                        film.Genres = line.Replace("|", ", ");

                    }
                    Movies.Add(film);

                }

                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
            }
        }

        public override void Search(String ti)
        {
            //// var movies = Movies.Where(m => m.title.Contains("(1990)"));  
            ////Console.WriteLine("Title is : " + ti);
            //var MovTitles = Movies.Where(m => m.Title.Contains((ti)));
            ////Console.WriteLine("Size of Show List is: " + ShowTitles.Count());

            //foreach (var item in MovTitles)
            //{
            //    Console.Write("This is a movie: ");
            //    Console.WriteLine(item.Title);

            //}

            foreach (var movie in context.Movies)
            {
                if (movie.Title.Contains(ti))
                {
                    Console.Write("ID: " + movie.Id + " ");
                    Console.WriteLine(movie.Title);
                }

            }
            Console.WriteLine("Done searching");


        }




    }
}