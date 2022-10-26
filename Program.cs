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
            Media Med2 = null;
            Media Med3 = null;

            Console.WriteLine("Press 1 to view movies");
            Console.WriteLine("Press 2 to view Show library ");
            Console.WriteLine("Press 3 to view  Video library");
Console.WriteLine("Press 4. To search for media:  ");
            Console.WriteLine("Press any other key to exit");
                
            var isValid = true;
            while (isValid)
            {
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                if (choice == "1")
                {
                    // Display Movies

                    med = new Movie();
                    med.Read();
                    med.Display();
                }
                else if (choice == "2")
                {
                    med = new Show();
                    med.Read();
                    med.Display();
                    //Console.WriteLine("Debugging: Made it past Show Display method");
                }
                else if (choice == "3")
                {
                    med = new Video();
                    med.Read();

                    //Console.WriteLine("Debugging:Made it to the main program after med.Red()");

                    med.Display();

                }

                else if (choice == "4") {
                    Console.Write("Enter title to search for: ");
                    var Title = Console.ReadLine();
            
                    med = new Movie();
                    med.Read();
                    Med2 = new Show();
                    Med2.Read();
                    Med3 = new Video();
                    Med3.Read();

                    med.Search(Title);
                    Med2.Search(Title);
                    Med3.Search(Title);
                
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
