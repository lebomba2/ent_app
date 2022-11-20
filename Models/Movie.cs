﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ComponentModel;
using MovieLibraryEntities.Context;
using MovieLibraryEntities.Models;
using System.Security.Cryptography.X509Certificates;
using Microsoft.EntityFrameworkCore;
using System.Collections;

namespace Entertainment_App.Models
{
    public class Movie : Media
    {
        private string _fileName;

        //    public string[] Genres { get; set;
        public string Genres;
        private List<Movie> Movies = new();
        private List<String> MovieTitles = new List<string>();
        private MovieContext context = new MovieContext();
        private DateTime ReleaseDate;
        
        public Movie()
        {
            //Console.WriteLine("movie object created");
        }
        public override void Delete()
        {
            Console.WriteLine("Enter the MovieId to delete");
            var movieIdToDelete = Convert.ToInt32(Console.ReadLine());
            //var movieToDelete = MovieContext.GetById(movieIdToDelete);


            //            var obj = myList.FirstOrDefault(x => x.MyFieldName == "fieldName")
            //if (obj != null)

            var MovieToRemove = context.Movies.FirstOrDefault(x => x.Id == movieIdToDelete);

            context.Remove(MovieToRemove);
            context.SaveChanges();

            //_repository.Delete(movieToDelete);
            Console.WriteLine("Movie was removed!");

        }

        public override void Update()
        {
            var movieIdToUpdate = Convert.ToInt32(Console.ReadLine());
            
            var MovieToUpdate = context.Movies.FirstOrDefault(x => x.Id == movieIdToUpdate);


            // note that we are assuming the user wants to update the title - again not good
            Console.WriteLine($"Here is your movie {MovieToUpdate.Title}");
            Console.WriteLine("What do you want to change title to?");
            var newTitle = Console.ReadLine();
            MovieToUpdate.Title = newTitle;
            context.Update(MovieToUpdate);
            context.SaveChanges();
            //context.Remove(MovieToRemove);
//            context.SaveChanges();




        }
        public override void Add()
        {
            // Add Movie To Database
            Console.WriteLine("Enter the movie title");
            var movieTitle = Console.ReadLine();

            Console.WriteLine("Enter the release date");
            var movieRelease = Console.ReadLine();
            var movieReleaseDate = DateTime.Parse(movieRelease);

            var movie = new Movie()
            {
                Title = movieTitle,
                ReleaseDate = movieReleaseDate
            };

            //context.Add(Movie);

        }
    
        public override void Display()
        {
            foreach (var movie in context.Movies)
            {
                Console.Write("MovieID: "  + movie.Id + " ");               Console.WriteLine(movie.Title);
            }


            //Console.WriteLine();
            //Console.WriteLine("movieId   title     genres");
            //;
            //// print out contents of Array 

            //foreach (var Movie in Movies)
            //{
            //    Console.Write(Movie.Id + " ");
            //    Console.Write(Movie.Title + " ");
            //    Console.WriteLine(Movie.Genres);
            //}

        }

        public override void Read()
        {
            _fileName = $"{Environment.CurrentDirectory}/Files/movies.csv";

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

                    var film = new Movie();

                    var line = sr.ReadLine();
                    // first look for quote(") in string
                    // this indicates a comma(,) in movie title
                    var idx = line.IndexOf('"');
                    if (idx == -1)
                    {
                        // no quote = no comma in movie title
                        // movie details are separated with comma(,)

                        //String strDetails; 
                        var movieDetails = line.Split(',');
                        //strDetails  = (String) movieDetails;
                        //Console.WriteLine(strDetails);

                        // 1st array element contains movie id
                        film.Id = int.Parse(movieDetails[0]);
                        // 2nd array element contains movie title
                        film.Title = movieDetails[1];
                        // 3rd array element contains movie genre(s)
                        // replace "|" with ", "
                        film.Genres = movieDetails[2].Replace("|", ", ");
                        // Add Film to Movie List
                        //Movies.Add(film);
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

                    }
                    Movies.Add(film);

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
            //// var movies = Movies.Where(m => m.title.Contains("(1990)"));  
            ////Console.WriteLine("Title is : " + ti);
            //var MovTitles = Movies.Where(m => m.Title.Contains((ti)));
            ////Console.WriteLine("Size of Show List is: " + ShowTitles.Count());

            //foreach (var item in MovTitles)
            //{
            //    Console.Write("This is a movie: ");
            //    Console.WriteLine(item.Title);

            //}

            foreach (var movie in context.Movies)
            {
                if (movie.Title.Contains(ti))
                {
                    Console.WriteLine(movie.Title);
                }
            }

        }

       


    }
}