﻿using OnlineMovieBooking.Domain.DTO;
using OnlineMovieBooking.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieBooking.Domain.Services.City
{
    public class CityQueryService : ICityQueryService
    {
        private readonly ICityRepository repository;

        public CityQueryService(ICityRepository repository)
        {
            this.repository = repository;
        }
    }
}