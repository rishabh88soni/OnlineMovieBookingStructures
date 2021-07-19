﻿using OnlineMovieBooking.Domain.Repository.Configuration;
using OnlineMovieBooking.Domain.Repository.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieBooking.Domain.Repository
{
    public class PaymentRepository : IPaymentRepository
    {
        private MovieContext db;
        public PaymentRepository()
        {
            db = new MovieContext();
        }
        public PaymentRepository(MovieContext context)
        {
            this.db = context;
        }
        public void Add(Payment payment)
        {
            db.Payments.Add(payment);
            db.SaveChanges();
        }
        public Payment GetById(int id)
        {
            return db.Payments.Find(id);
        }
        public void Update(Payment payment)
        {
            var s = GetById(payment.PaymentId);
            s = payment;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            var payment = GetById(id);
            db.Payments.Remove(payment);
            db.SaveChanges();
        }
        public List<Payment> GetAll()
        {
            return db.Payments.ToList();
        }
    }
}
