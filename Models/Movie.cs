using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 


namespace Entertainment_App.Models
{
    public class Movie : Media
    {   
    //    public string[] Genres { get; set;
      public String Genres;

        private string _fileName;
        private List<Movie> Movies = new();

        public Movie() {
            Console.WriteLine("movie object created");
        }

        public override  void Read() {
            _fileName = $"{Environment.CurrentDirectory}/movies.csv";

            Movie film = new Movie();

            try
            {
                StreamReader sr = new StreamReader(_fileName);
                // first line contains column headers
                sr.ReadLine();
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in movie title
                    int idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in movie title
                        // movie details are separated with comma(,)
                        string[] movieDetails = line.Split(',');
                        // 1st array element contains movie id
                        film.Id = int.Parse(movieDetails[0]);
                        // 2nd array element contains movie title
                        film.Title = movieDetails[1];
                        // 3rd array element contains movie genre(s)
                        // replace "|" with ", "
                        film.Genres =   movieDetails[2].Replace("|", ", ");
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

                
        public override      void Display()
                        // print out contents of Array 
            for (int i  = 0; i < Movies.Count();i++) {
                Console.Write(Movies[i].Id  + " ");
            Console.WriteLine(Movies[i].Genres);
                Console.W   rite(Movies[i].Title + " ");
            }




            throw new NotImplementedException();
        }
    }
}
