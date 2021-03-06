using OnlineMovieBooking.Domain.Repository.Configuration;
using OnlineMovieBooking.Domain.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieBooking.Domain.Repository
{
    public class ShowSeatRepository : IShowSeatRepository
    {
        private MovieContext db;
        public ShowSeatRepository()
        {
            db = new MovieContext();
        }
        public ShowSeatRepository(MovieContext context)
        {
            this.db = context;
        }
        public void Add(ShowSeat showSeat)
        {
            db.ShowSeats.Add(showSeat);
            db.SaveChanges();
        }
        public ShowSeat GetById(int id)
        {
            return db.ShowSeats.Find(id);
        }
        public void Update(int id, ShowSeat showSeat)
        {
            var s = GetById(id);
            s = showSeat;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var showSeat = GetById(id);
            db.ShowSeats.Remove(showSeat);
            db.SaveChanges();
        }
        public List<ShowSeat> GetAll()
        {
            return db.ShowSeats.Include(s => s.Booking).Include(s => s.CinemaSeat).Include(s => s.Show).ToList();
        }

        public List<ShowSeat> GetByShowId(int id)
        {
            return db.ShowSeats.Where(m => m.ShowId == id).ToList();

        }

        public ShowSeat GetByBookinId(int id)
        {
            return (ShowSeat)db.ShowSeats.Where(m => m.BookingId == id);
        }

        public string GetStatus(int id)
        {
            ShowSeat ss = GetById(id);
            return ss.Status;
        }

        public double GetPrice(int id)
        {
            ShowSeat ss = GetById(id);
            return ss.Price;
        }
    }
}
