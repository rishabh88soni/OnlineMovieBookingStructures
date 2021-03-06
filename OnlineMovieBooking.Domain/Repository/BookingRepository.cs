using OnlineMovieBooking.Domain.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineMovieBooking.Domain.Repository.Configuration;

namespace OnlineMovieBooking.Domain.Repository

{
    public class BookingRepository : IBookingRepository
    {
        private MovieContext db;
        
        public BookingRepository() 
        {
            this.db = new MovieContext();
        }
        public BookingRepository(MovieContext movieContext)
        {
            this.db = movieContext;
        }
        public bool Add(Booking booking)
        {
            db.Bookings.Add(booking);
            db.SaveChanges();
            return true;
        }
        public void Delete(int id)
        {
            var booking = db.Bookings.Find(id);
            if(booking!=null)
            {
                db.Bookings.Remove(booking);
                db.SaveChanges();
            }
        }

        public void Update(int id,Booking booking)
        {
            var book = GetById(id);
            book = booking;
            db.SaveChanges();
        }

        public List<Booking> GetAll()
        {
            return db.Bookings.ToList();
        }

        public Booking GetById(int id)
        {
            return db.Bookings.Find(id);
        }

        public int GetNumberOfSeats(int id)
        {
            Booking booking = db.Bookings.Find(id);
            return booking.NumberOfSeats;
        }

        public string GetStatus(int id)
        {
            Booking booking = db.Bookings.Find(id);
            return booking.Status;
        }

        public List<Booking> GetByUserId(int id)
        {
            List<Booking> list = db.Bookings.Where(m => m.UserId == id).ToList();
            return list;
        }

        public List<Booking> GetByShowId(int id)
        {
            List<Booking> list = db.Bookings.Where(m => m.ShowId == id).ToList();
            return list;
        }
    }
}
