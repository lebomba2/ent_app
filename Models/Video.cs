using System;
using System.Collections.Generic;

namespace Entertainment_App.Models
{
    public class Video : Media
    {
        private string _fileName;
        private List<Video> Videos = new();
        public string Format { get; set; }

        public int Id { get; set; }
        public int Length { get; set; }
        public int[] Regions { get; set; }
        public string Title { get; set; }

        public override void Display()
        {
            throw new NotImplementedException();
        }

        public override void Read()
        {
            _fileName = $"{Environment.CurrentDirectory}/Files/Videos.csv";
        }
    }
}
