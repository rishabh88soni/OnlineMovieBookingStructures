﻿using OnlineMovieBooking.Domain.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieBooking.Domain.Services.CinemaSeatService
{
    public interface ICinemaSeatQueryService
    {
        CinemaSeat Get(int id);
        List<CinemaSeat> GetAll();
    }
}