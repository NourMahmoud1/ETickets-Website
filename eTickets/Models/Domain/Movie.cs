﻿using eTickets.Data.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eTickets.Models.Domain
{
    public class Movie
    {
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string? PosterURL { get; set; }
        public string ImageURL { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public MovieCategory MovieCategory { get; set; }
        //Relationships
        public ICollection<Actor_Movie> ActorsMovies { get; set; }
        //producer
        [ForeignKey("ProducerId")]
        public Guid ProducerId { get; set; }
        public Producer Producer { get; set; }
        //cinema
        public ICollection<Cinema_Movie> CinemasMovies { get; set; }
    }
}
