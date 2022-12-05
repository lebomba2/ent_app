using System;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;


namespace Entertainment_App.Models
{
    class Occupation
    {

        public String Name { get; set; }
        public Occupation()
        {
            var factory = LoggerFactory.Create(b => b.AddConsole());
            var logger = factory.CreateLogger<Program>();
            logger.LogInformation("Inside Occupation  default constructor");

            Name = "unknown";
        }

        public void AddName()
        {

            Console.Write("Enter occupation name: ");
            this.Name = Console.ReadLine();
        }
    }
}