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

namespace Entertainment_App.Models
{
    class User
    {
        public int Age{ get; set;}
    public String   Gender { get; set; }

        public String ZipCode { get; set;}
        

        public User()
        {
Gender = "Unknown";
            ZipCode = "Unknown";
            Age = 0;

        }
        public void CreateUser() {
            Console.Write("Enter user's Age: ");
            this.Age = Convert.ToInt32( Console.ReadLine());

            Console.Write("Enter user's gender: ");
            this.Gender = Console.ReadLine();
            Console.Write("Enter user's zip code: ");
this.ZipCode = Console.ReadLine();  
        
        }

    }
}