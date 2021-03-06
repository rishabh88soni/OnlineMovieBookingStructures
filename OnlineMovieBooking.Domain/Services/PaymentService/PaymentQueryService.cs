using OnlineMovieBooking.Domain.DTO;
using OnlineMovieBooking.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieBooking.Domain.Services.PaymentService
{
    public class PaymentQueryService : IPaymentQueryService
    {
        private readonly IPaymentRepository repository;
        private PaymentRepository pr;
        public PaymentQueryService() { }
        public PaymentQueryService(IPaymentRepository repository)
        {
            this.repository = repository;
        }
        public Payment Get(int id)
        {
            Repository.Entities.Payment payment = pr.GetById(id);
            Payment p = new Payment
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                Time = payment.Time,
                DiscountCouponId = payment.DiscountCouponId,
                RemoteTransactionId = payment.RemoteTransactionId,
                PaymentMethod = payment.PaymentMethod,
                BookingId = payment.BookingId
            };
            return p;
        }

        public List<Payment> GetAll()
        {
            var retList = pr.GetAll()
            .Select(payment => new Payment()
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                Time = payment.Time,
                DiscountCouponId = payment.DiscountCouponId,
                RemoteTransactionId = payment.RemoteTransactionId,
                PaymentMethod = payment.PaymentMethod,
                BookingId = payment.BookingId
            }).ToList();
            return retList;
        }
    }
}
