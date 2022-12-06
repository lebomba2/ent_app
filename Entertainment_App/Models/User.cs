using MovieLibraryEntities.Context;
using System;
using System.Linq;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;

namespace Entertainment_App.Models
{
    class User
    {
        public int Age { get; set; }
        public String Gender { get; set; }
        private MovieContext context = new MovieContext();

        public String ZipCode { get; set; }

        public User()
        {
            var factory = LoggerFactory.Create(b => b.AddConsole());
            var logger = factory.CreateLogger<Program>();
            logger.LogInformation("Inside User default constructor");

            Gender = "Unknown";
            ZipCode = "Unknown";
            Age = 0;
        }


        public void Add()
        {
            var OCCUPATIONS = context.Occupations.ToList();

            Console.WriteLine("List of occupations:");

            foreach (var occupation in OCCUPATIONS)
            {
                Console.WriteLine(occupation.Name);
            }

            var newUser = new MovieLibraryEntities.Models.User();
            var newOccupation = new MovieLibraryEntities.Models.Occupation();
            //var newOccupation = context.Occupations.FirstOrDefault(x => x.Name == "Scientist");
            Console.Write("Enter occupation from list: ");
            newOccupation.Name = Console.ReadLine();
            newUser.Occupation = newOccupation;

            var age = 0;
            bool IsValid = false;


            while (IsValid == false)
            {

                Console.Write("Enter user's Age: ");
                age = Convert.ToInt32(Console.ReadLine());
                if (age <= 0)
                {
                    Console.WriteLine("Invalid: Must enter a number greater than 0.");
                }
                else if (age >= 109)
                {
                    Console.WriteLine("Invalid: You must enter an age less than 110");
                }

                else
                {
                    newUser.Age = age;
                    IsValid = true;
                }
            }
            Console.Write("Enter user's gender: ");
            newUser.Gender = Console.ReadLine();
            Console.Write("Enter user's zip code: ");
            newUser.ZipCode = Console.ReadLine();

            context.Add(newUser);
            context.SaveChanges();

            Console.WriteLine("New user was added.");
            var LastUserEntered = context.Users.OrderBy(x => x.Id).LastOrDefault();
            Console.WriteLine("User ID: " + LastUserEntered.Id
                + " Age: " + LastUserEntered.Age
                + " Gender: " + LastUserEntered.Gender
                + " Zip: " + LastUserEntered.ZipCode
                + " Occupation: " + LastUserEntered.Occupation.Name);
        }


    }
}
