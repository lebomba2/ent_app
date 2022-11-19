using System;
using Entertainment_App.Models;
using System.Linq;


namespace Entertainment_App
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Media med = null;
            
            Console.WriteLine("Press 1 to view movies");
            Console.WriteLine("Press 2 Add Movie");
            Console.WriteLine("Press 3 to To Delete Movie");
Console.WriteLine("Press 4. To search for Movie:  ");
            Console.WriteLine("Press 5. To Update");
            Console.WriteLine("Press any other key to exit");
                
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

                    // Add Movie 
                }
                else if (choice == "3")
                {
                    // Delete Movie
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

                else if (choice == "5") { 
                // update Movie Listing


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
