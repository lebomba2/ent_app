using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Metadata.Ecma335;
using System.Linq;
namespace Entertainment_App.Models
{
    public class Show : Media
    {
        private string _fileName;
        private List<Show> Shows = new();
        public int Episode { get; set; }
        public int Season { get; set; }
        public string Writer { get; set; }
        private List<String> ShowTitles = new List<string>();

        // Defau    lt constructor 
        public Show(    ) { }


                   
       

        public override void Display()
        {
            // print out contents of Array 
            Console.WriteLine();
           Console.WriteLine("showId    title    season    episode    writer ");

            foreach (var show in Shows)

            {
                Console.Write(show.Id + " ");
                Console.Write(show.Title + " ");
                Console.Write(show.Season + " ");
                Console.Write(show.Episode + " ");
                Console.WriteLine(show.Writer);

            }
        }
            


        public override void Read()
        {

            _fileName = $"{Environment.CurrentDirectory}/Files/Shows.csv";

            //_fileName = $"{Environment.CurrentDirectory}/Files/";
                
                    if (!File.Exists(_fileName))
            {
                Console.WriteLine($"File does not exist {_fileName}");
            }


            try
            {
                var sr = new StreamReader(_fileName);
                
                // first line contains column headers
                sr.ReadLine();
                
                
                while (!sr.EndOfStream)
                {

                    var TvShow = new Show();

                    var line = sr.ReadLine();
                   
                    // first look for quote(") in string
                    // this indicates a comma(,) in show title
                    var idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in show  title
                        // show  details are separated with comma(,)
                        var ShowDetails = line.Split(',');
                        // 1st array element contains show id
                        TvShow.Id = int.Parse(ShowDetails[0]);
                        // 2nd array element contains show title
                        TvShow.Title = ShowDetails[1];

                        
                        // 3rd array element contains  seasont (s)
                        TvShow.Season = int.Parse(ShowDetails[2]);
                        // fourth  array element contains  episode  (s)
                        TvShow.Episode = int.Parse(ShowDetails[3]);

                        // fifth array element contains show  writer
                        TvShow.Writer  = ShowDetails[4];

                                        // Add TV show  to List
                        //Movies.Add(film);
                    }
                    else
                    {
                        // quote = comma in show title
                        // extract the 
                        TvShow.Id = int.Parse(line.Substring(0, idx - 1));
                        // remove Show ID and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the e
                        TvShow.Title = line.Substring(0, idx);
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                       
                    }
            //        Console.WriteLine("right before add tv show to list");
                    Shows.Add(TvShow);

                }

                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
            }
        }
        public override void Search(String ti)
        {
            // var movies = Movies.Where(m => m.title.Contains("(1990)"));  
            //Console.WriteLine("Title is : " + ti);
            var ShowTitles = Shows.Where(s => s.Title.Contains((ti)));
            //Console.WriteLine("Size of Show List is: " + ShowTitles.Count());

            foreach (var item in ShowTitles)
            {
                Console.Write("This is a show: ");
                Console.WriteLine(item.Title);

            }

        }



    }
}