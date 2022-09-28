using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entertainment_App.Models
{
    public class Video : Media
    {

       public int Id { get; set; }
        public String Title { get; set; }
        public string Format { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }
        private string _fileName; 
        private List<Video> Videos = new List<Video>();


        public Video() { 
        
        }

        public override void Read() {
            _fileName = $"{Environment.CurrentDirectory}/Videos.csv";



        }


        public override void Display()
        {
            throw new NotImplementedException();
        }
    }
}
