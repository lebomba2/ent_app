using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment_App.Models
{
    public class Show : Media
    {
        public int Episode { get; set; }
        public int              Season { get; set; }
        public string[] Writers { get; set; }
        private string _fileName;
        private List<Show> Shows = new List<Show>();


        public Show() { 
        
        }

        public override void Read() {
            _fileName = $"{Environment.CurrentDirectory}/Shows.csv";



        }
        public override void  Display()
        {
            throw new NotImplementedException();
        }
    }
}
