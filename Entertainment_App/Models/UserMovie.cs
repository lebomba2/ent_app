using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;

namespace Entertainment_App.Models
{
    class UserMovie
    {
        public int Rating { get; set; }
        public DateTime RatingAt { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        private MovieContext context = new MovieContext();

        // Default Constructor
        public UserMovie()
        {
            Rating = 1;
            RatingAt = DateTime.Now;
            UserId = 0;
            MovieId = 0;
        }

        public void TopRated()
        {
            //List top rated movie by age bracket or occupation
            //Sort alphabetically and by rating and display just the first movie
            Console.WriteLine("Do you want to view top rated movies by ");
            Console.WriteLine("age or by occupation? Press A for age or O for occupation ");
            var choice = Console.ReadLine();
            if (choice == "A" || choice == "a")
            {
                Console.WriteLine("You have entered A for age");
                Console.Write("Enter an Age; ");
                var age = Console.ReadLine();
            }
            else if (choice == "O" || choice == "o")
            {
                Console.WriteLine("You have typed o for occupation");
                Console.Write("Enter an occupation: ");
                var occ = Console.ReadLine();

            }
            else
            {
                Console.WriteLine("You have made an invalid selection. ");
            }
        }

        public void AddUserMovie()
        {

            // Get User ID from user
            Console.Write("Enter User ID: ");
            UserId = Convert.ToInt32(Console.ReadLine());



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
            Console.Write("What do you want to rate this movie as: ");
            userMovie.Rating = Convert.ToInt32(Console.ReadLine());
            userMovie.RatedAt = DateTime.Now;

            // set up the database relationships
            userMovie.User = user;
            userMovie.Movie = movieToRate;

            // db.Users.Add(user);
            context.UserMovies.Add(userMovie);

            // commit
            context.SaveChanges();

            Console.WriteLine("New rating was added.");
            var LastRatingEntered = context.UserMovies.OrderBy(x => x.RatedAt).LastOrDefault();
            Console.WriteLine("Last Movie Rated: " + LastRatingEntered.Movie.Title);
            Console.WriteLine("Movie recieved a rating of: " + LastRatingEntered.Rating);
            Console.WriteLine("Rated by user: " + LastRatingEntered.User);

            Console.WriteLine("Rated at: " + LastRatingEntered.RatedAt);
        }


    }
}
