using Entertainment_App.Models;
using System;

namespace Entertainment_App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Models.Media  med = null;

            Console.WriteLine("Press 1 to view movies");
            Console.WriteLine("Press 2 to view Show library ");
            Console.WriteLine("Press 3 to view  Video library");
            Console.WriteLine("Press any other key to exit");

            bool isValid = true;
            while (isValid == true) {

                Console.Write("Enter your choice: ");
                String choice = Console.ReadLine();

                if (choice == "1") {
                    // Display Movies
                    
                    med = new Movie();
                    med.Display();


                }
                else if (choice == "2") {

                    med = new Show();

                }
                else if (choice == "3") {
                    med = new Video();  
                
                }
                else {
                    isValid = false;
                    Console.WriteLine("You have exited the program.");
                }


            
            }
        
        }
    }
}
                