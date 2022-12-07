using Entertainment_App.Models;
using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace Entertainment_App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Media med = null;
            var factory = LoggerFactory.Create(b => b.AddConsole());
            var logger = factory.CreateLogger<Program>();
            //logger.LogInformation("Program has started");

            var isValid = true;

            while (isValid)
            {
                Console.WriteLine();
                Console.WriteLine("Press 1 to view movies");
                Console.WriteLine("Press 2 Add Movie");
                Console.WriteLine("Press 3 to To Delete Movie");
                Console.WriteLine("Press 4. To search for Movie:  ");
                Console.WriteLine("Press 5. To Update");
                Console.WriteLine("Press 6 to enter new user: ");
                Console.WriteLine("Press 7 to rate a movie:");
                Console.WriteLine("Press 8 to see top rated movies:");
                Console.WriteLine("Press any other key to exit");
                Console.WriteLine("Press 9 to see Golden Raspberry elligible movies: ");

                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    // uncomment if you want to see logger information     
                    //logger.LogInformation("In program.cs Display method");

                    // Dis  play Movies
                    med = new Movie();
                    med.Display();
                }
                else if (choice == "2")
                {
                    //logger.LogInformation("Program has Add movie in main  main");

                    med = new Movie();
                    med.Add();

                    // Add Movie 
                }
                else if (choice == "3")
                {
                    // uncomment if you want to see logger information     
                    //logger.LogInformation("Program in delete portion of main program");

                    // Delete Movie
                    med = new Movie();
                    med.Delete();
                }

                else if (choice == "4")
                {
                    // uncomment if you want to see logger information     
                    //logger.LogInformation("Program is in search method");

                    Console.Write("Enter title to search for: ");
                    var Title = Console.ReadLine();

                    med = new Movie();
                    med.Read();
                    med.Search(Title);

                }

                else if (choice == "5")
                {
                    // uncomment if you want to see logger information     
                    //logger.LogInformation("Program in search method in main ");

                    // update Movie Listing
                    med = new Movie();
                    med.Update();
                }
                else if (choice == "6")
                {
                    User NewUser = new User();
                    //logger.LogInformation("Program is in create new user in maind");

                    //NewUser.CreateUser(NewUser);
                    NewUser.Add();
                }
                else if (choice == "7")
                {

                    UserMovie uMovie = new UserMovie();
                    uMovie.AddUserMovie();
                }
                else if (choice == "8")
                {
                    UserMovie UserRating = new UserMovie();
                    UserRating.TopRated();
                }
                else if (choice == "9")
                {
                    //logger.LogInformation("Program is in searching for lowest rated movie");

                    UserMovie UserRating = new UserMovie();
                    UserRating.lowestRated();
                }
                else
                {
                    isValid = false;
                    Console.WriteLine("You have exited the program.");
                }
            }
        }
    }
}