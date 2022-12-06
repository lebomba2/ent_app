using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;

namespace Entertainment_App.Models
{
    class UserMovie
    {
        private int Rating { get; set; }
        private DateTime RatingAt { get; set; }
        private int UserId { get; set; }
        private int MovieId { get; set; }
        private MovieContext context = new MovieContext();

        /*
        
psuedo code to check if an item exists
  var movies = db.Movies.Where(x=>x.Title.Contains("Utopia"));
    if (movies.Any()) // this returns a true/false boolean
    {
        // process if any exist
    }

       */
        // Default Constructor
        public UserMovie()
        {
            var factory = LoggerFactory.Create(b => b.AddConsole());
            var logger = factory.CreateLogger<Program>();
            // Uncomment to utilize logger. 
            //logger.LogInformation("Inside UserMovie default constructor");

            Rating = 1;
            RatingAt = DateTime.Now;
            UserId = 0;
            MovieId = 0;
        }

        public void lowestRated()
        {
            //needed for title case
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            //List lowest rated movie by age bracket or occupation
            //Sort alphabetically and by rating and display just the first movie
            Console.WriteLine("Do you want to view lowest rated movies by ");
            Console.WriteLine("age or by occupation? Press A for age or O for occupation ");
            var choice = Console.ReadLine();
            if (choice == "A" || choice == "a")
            {

                bool IsValid = false;
                var age = 0;
                while (IsValid == false)
                {
                    Console.Write("Enter an Age:  ");
                    age = Convert.ToInt32(Console.ReadLine());
                    if (age <= 0)
                    {
                        Console.WriteLine("Invalid: You entered a number below 1.");
                    }
                    else if (age >= 109)
                    {
                        Console.WriteLine("Invalid: You cannot enter a number over 109.");
                    }
                    else
                    {
                        IsValid = true;
                    }
                }
                // end of while loop}}

                //find all movies reviewed by x age
                var moviesByAge = context.UserMovies.Where(m => m.User.Age == age).ToList();
                Console.WriteLine(" Searching Movies by age: ");
                //print out all movies found, or indicate none found by age
                if (moviesByAge.Count > 0)
                {
                    //get lowest movie
                    var lowestRatedByAge = moviesByAge.OrderBy(m => m.Rating).LastOrDefault();
                    Console.WriteLine("Lowest Rated Movie by age is: " + lowestRatedByAge.Movie.Title);
                }
                else
                {
                    Console.WriteLine("No movies found by that age.");
                }
            }
            else if (choice == "O" || choice == "o")
            {
                Console.Write("Enter an Occupation: ");
                var occupation = Console.ReadLine();
                //convert to title case
                occupation = textInfo.ToTitleCase(occupation);
                //find all movies reviewed by  Occupation x
                var moviesByOccupation = context.UserMovies.Where(m => m.User.Occupation.Name == occupation).ToList();

                Console.WriteLine("Found Movies by occupation: ");
                //print out all movies found, or indicate none found by age
                if (moviesByOccupation.Count > 0)
                {
                    //get lowest movie
                    var lowestRatedByOccupation = moviesByOccupation.OrderBy(m => m.Rating).LastOrDefault();
                    Console.WriteLine("Lowest Rated Movie by occupation: " + lowestRatedByOccupation.Movie.Title);
                }
                else
                {
                    Console.WriteLine("No movies found by that occupation.");
                }
            }
            else
            {
                Console.WriteLine("You have made an invalid selection. ");
            }
        }

        public void TopRated()
        {
            //needed for title case
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;

            //List top rated movie by age bracket or occupation
            //Sort alphabetically and by rating and display just the first movie
            Console.WriteLine("Do you want to view top rated movies by ");
            Console.WriteLine("age or by occupation? Press A for age or O for occupation ");
            var choice = Console.ReadLine();
            if (choice == "A" || choice == "a")
            {
                bool IsValid = false;
                var age = 0;
                while (IsValid == false)
                {
                    Console.Write("Enter an Age:  ");
                    age = Convert.ToInt32(Console.ReadLine());
                    if (age <= 0)
                    {
                        Console.WriteLine("Invalid: You entered a number below 1.");
                    }
                    else if (age >= 109)
                    {
                        Console.WriteLine("Invalid: You cannot enter a number over 109.");
                    }
                    else
                    {
                        IsValid = true;
                    }
                }
                // end of while loop}}

                //find all movies reviewed by x age
                var moviesByAge = context.UserMovies.Where(m => m.User.Age == age).ToList();
                Console.WriteLine("Searching Movies by age: ");
                //print out all movies found, or indicate none found by age
                if (moviesByAge.Count > 0)
                {
                    //get top movie
                    var topRatedByAge = moviesByAge.OrderBy(m => m.Rating).FirstOrDefault();
                    Console.WriteLine("Top Movie by age is: " + topRatedByAge.Movie.Title);
                }
                else
                {
                    Console.WriteLine("No movies found by that age.");
                }
            }
            else if (choice == "O" || choice == "o")
            {
                Console.Write("Enter an Occupation: ");
                var occupation = Console.ReadLine();
                //convert to title case
                occupation = textInfo.ToTitleCase(occupation);
                //find all movies reviewed by  Occupation x
                var moviesByOccupation = context.UserMovies.Where(m => m.User.Occupation.Name == occupation).ToList();

                Console.WriteLine("Found Movies by occupation: ");
                //print out all movies found, or indicate none found by age
                if (moviesByOccupation.Count > 0)
                {
                    //get top movie
                    var topRatedByOccupation = moviesByOccupation.OrderBy(m => m.Rating).FirstOrDefault();
                    Console.WriteLine("Top Movie by occupation: " + topRatedByOccupation.Movie.Title);
                }
                else
                {
                    Console.WriteLine("No movies found by that occupation.");
                }
            }
            else
            {
                Console.WriteLine("You have made an invalid selection. ");
            }
        }

        public void AddUserMovie()
        {

            // Get User ID from user
            int UserId = 0;
            while (UserId == 0)
            {
                Console.Write("Enter User ID: ");
                bool success = int.TryParse(Console.ReadLine(), out UserId);
                if (success == false)
                {
                    Console.WriteLine("You have entered a non integer.");
                }
            }

            var MovieTitle = "";

            // build user object (not database)
            Console.Write("Enter the movie title you want to search for: ");
            MovieTitle = Console.ReadLine();
            //var Title = Console.ReadLine();

            var user = context.Users.FirstOrDefault(u => u.Id == UserId);

            Movie movie = new Movie();
            movie.Read();

            // Display Movies to Screen
            movie.Search(MovieTitle);
            Console.WriteLine("Choose the movie ID you want to rate: ");
            var idToRate = Convert.ToInt32(Console.ReadLine());

            var movieToRate = context.Movies.FirstOrDefault(m => m.Id == idToRate);

            var userMovie = new MovieLibraryEntities.Models.UserMovie();

            var UserRating = 0;
            bool IsRatingValid = false;
            while (IsRatingValid == false)
            {
                Console.Write("What do you want to rate this movie as choose a number from 1 to 5: ");
                UserRating = Convert.ToInt32(Console.ReadLine());

                // check to see if the rating is in bounds
                if (UserRating >= 1 && UserRating <= 5)
                {
                    IsRatingValid = true;
                }
            }

            userMovie.Rating = UserRating;
            userMovie.RatedAt = DateTime.Now;

            // set up the database relationships
            userMovie.User = user;
            userMovie.Movie = movieToRate;

            context.UserMovies.Add(userMovie);

            // commit
            context.SaveChanges();

            Console.WriteLine("New rating was added.");
            var LastRatingEntered = context.UserMovies.OrderBy(x => x.RatedAt).LastOrDefault();
            Console.WriteLine("Last Movie Rated: " + LastRatingEntered.Movie.Title);
            Console.WriteLine("Movie recieved a rating of: " + LastRatingEntered.Rating);
            Console.WriteLine("Rated by user: " + LastRatingEntered.User.Id);

            Console.WriteLine("Rated at: " + LastRatingEntered.RatedAt);
        }


    }
}