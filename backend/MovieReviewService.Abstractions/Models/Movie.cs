using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieReviewService.Abstractions.Models;

namespace MovieReviewService.Abstractions;

    public class Movie
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<MovieType> MovieTypes { get; set; }


    }

