using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Entertainment_App.Models
{
    public class Movie : Media
    {
        private string _fileName;

        //    public string[] Genres { get; set;
        public string Genres;
        private readonly List<Movie> Movies = new();

        public Movie()
        {
            Console.WriteLine("movie object created");
        }

        public override void Display()
        {
            // print out contents of Array 
            for (var i = 0; i < Movies.Count(); i++)
            {
                Console.Write(Movies[i].Id + " ");
                Console.WriteLine(Movies[i].Genres);
                Console.Write(Movies[i].Title + " ");
            }
        }

        public override void Read()
        {
            _fileName = $"{Environment.CurrentDirectory}/movies.csv";

            var film = new Movie();

            try
            {
                var sr = new StreamReader(_fileName);
                // first line contains column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    var line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in movie title
                    var idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in movie title
                        // movie details are separated with comma(,)
                        var movieDetails = line.Split(',');
                        // 1st array element contains movie id
                        film.Id = int.Parse(movieDetails[0]);
                        // 2nd array element contains movie title
                        film.Title = movieDetails[1];
                        // 3rd array element contains movie genre(s)
                        // replace "|" with ", "
                        film.Genres = movieDetails[2].Replace("|", ", ");
                        // Add Film to Movie List
                        Movies.Add(film);
                    }
                    else
                    {
                        // quote = comma in movie title
                        // extract the 
                        film.Id = int.Parse(line.Substring(0, idx - 1));
                        // remove movieId and first quote from string
                        line = line.Substring(idx + 1);
                        // find the next quote
                        idx = line.IndexOf('"');
                        // extract the e
                        film.Title = line.Substring(0, idx);
                        // remove title and last comma from the string
                        line = line.Substring(idx + 2);
                        // replace the "|" with ", "
                        film.Genres = line.Replace("|", ", ");

                        // Add film object to Movie List
                        Movies.Add(film);
                    }
                }

                // close file when done
                sr.Close();
            }
            catch (Exception ex)
            {
            }
        }
    }
}
