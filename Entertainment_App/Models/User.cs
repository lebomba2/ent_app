using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics.CodeAnalysis;

namespace Entertainment_App.Models
{
    class User
    {
        public int Age{ get; set;}
    public String   Gender { get; set; }
        private MovieContext context = new MovieContext();


        public String ZipCode { get; set;}
        

        public User()
        {
            Gender = "Unknown";
            ZipCode = "Unknown";
            Age = 0;
        }

 //       public User  CreateUser(User Doe) {
 //           Console.Write("Enter user's Age: ");
 //Doe.Age               = Convert.ToInt32( Console.ReadLine());

 //           Console.Write("Enter user's gender: ");
 //           Doe.Gender = Console.ReadLine();
 //           Console.Write("Enter user's zip code: ");
 // Doe.ZipCode  = Console.ReadLine();

 //           return Doe;
 //       }

        public void Add() {
            var newUser = new MovieLibraryEntities.Models.User();
            //var newOccupation = new MovieLibraryEntities.Models.Occupation();
                var newOccupation = context.Occupations.FirstOrDefault(x => x.Name == "Scientist");
            newUser.Occupation = newOccupation;


            Console.Write("Enter user's Age: ");
            newUser.Age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter user's gender: ");
            newUser.Gender = Console.ReadLine();
            Console.Write("Enter user's zip code: ");
            newUser.ZipCode = Console.ReadLine();

            //occupation stuff
            // loop through newOccupation object the same way you did for movie list from database
            //  and print to screen for user to choose
            // save to newUser object 

            context.Add(newUser);
            context.SaveChanges();

            Console.WriteLine("New user was added.");
        }


    }
}