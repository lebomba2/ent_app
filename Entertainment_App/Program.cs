﻿using Entertainment_App.Models;
using System;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.Console;


namespace Entertainment_App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Media med = null;
            //var factory = LoggerFactory.Create(b => b.AddConsole());
            
            //var logger = factory.CreateLogger<Program>();



            Console.WriteLine("Press 1 to view movies");
            Console.WriteLine("Press 2 Add Movie");
            Console.WriteLine("Press 3 to To Delete Movie");
            Console.WriteLine("Press 4. To search for Movie:  ");
            Console.WriteLine("Press 5. To Update");
            Console.WriteLine("Press 6 to enter new user: ");
            Console.WriteLine("Press 7 to rate a movie:");
            Console.WriteLine("Press 8 to see top rated movies:");
            Console.WriteLine("Press any other key to exit");
            Console.WriteLine("Press 9 to see Golden Raspberry elgible movies: ");
            var isValid = true;
            while (isValid)
            {
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Dis  play Movies
                    med = new Movie();
                    med.Display();
                }
                else if (choice == "2")
                {
                    med = new Movie();
                    med.Add();


                    // Add Movie 
                }
                else if (choice == "3")
                {
                    // Delete Movie
                    med = new Movie();
                    med.Delete();
                }

                else if (choice == "4")
                {
                    Console.Write("Enter title to search for: ");
                    var Title = Console.ReadLine();

                    med = new Movie();
                    med.Read();

                    med.Search(Title);

                }

                else if (choice == "5")
                {
                    // update Movie Listing
                    med = new Movie();
                    med.Update();
                }
                else if (choice == "6")
                {
                    User NewUser = new User();

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
                else if (choice == "9") {
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