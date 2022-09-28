using System;
using System.Collections.Generic;

namespace Entertainment_App.Models
{
    public class Show : Media
    {
        private string _fileName;
        private List<Show> Shows = new();
        public int Episode { get; set; }
        public int Season { get; set; }
        public string[] Writers { get; set; }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Read()
        {
            _fileName = $"{Environment.CurrentDirectory}/Shows.csv";
        }
    }
}
