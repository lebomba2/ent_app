using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment_App.Models
{
    class Occupation
    {

        public String Name { get; set; }
        public Occupation()
        {
            Name = "unknown";
        }

        public void AddName() {

            Console.Write("Enter occupation name: ");
            this.Name = Console.ReadLine();
        }
    }
}