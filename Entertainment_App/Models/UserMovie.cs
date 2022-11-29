using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieLibraryEntities.Context;


namespace Entertainment_App.Models
{
     class UserMovie
    {
        public int Rating  { get; set; }
        public DateTime RatingAt  { get; set; }
        public int UserId  { get; set; }
        public int MovieId { get; set; }
        private MovieContext context = new MovieContext();

        // Default Constructor
        public UserMovie() {
            Rating = 1;
            RatingAt = DateTime.Now;
            UserId = 0 ;
            MovieId = 0; 

        }

        public void AddUserMovie() { 
        
        }

    }
}
