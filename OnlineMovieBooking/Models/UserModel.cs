﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel;
using OnlineMovieBooking.Domain.DTO;

namespace OnlineMovieBooking.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string MobileNo { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<BookingModel> Bookings { get; set; }

        public static explicit operator UserModel(User v)
        {
            throw new NotImplementedException();
        }
    }
}