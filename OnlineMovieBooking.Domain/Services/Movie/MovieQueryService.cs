﻿using OnlineMovieBooking.Domain.DTO;
using OnlineMovieBooking.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieBooking.Domain.Services.Movie
{
    public class MovieQueryService : IMovieQueryService
    {
        private readonly IMovieRepository repository;

        public MovieQueryService(IMovieRepository repository)
        {
            this.repository = repository;
        }
    }
}