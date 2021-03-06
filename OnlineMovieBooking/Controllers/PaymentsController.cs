using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineMovieBooking.ViewModels;
using OnlineMovieBooking.ControllerService;
using OnlineMovieBooking.Models;

namespace OnlineMovieBooking.Controllers
{
    public class PaymentsController : Controller
    {
        private PaymentControllerService pcs = new PaymentControllerService();
        private BookingControllerService bcs = new BookingControllerService();
        

        // GET: Payments
        public ActionResult Index()
        {
            List<PaymentModel> pms = pcs.GetAll();
            List<PaymentViewModel> pvms = new List<PaymentViewModel>();
            foreach (var payment in pms)
            {
                PaymentViewModel p = new PaymentViewModel
                {
                    PaymentId = payment.PaymentId,
                    Amount = payment.Amount,
                    Time = payment.Time,
                    DiscountCouponId = payment.DiscountCouponId,
                    RemoteTransactionId = payment.RemoteTransactionId,
                    PaymentMethod = payment.PaymentMethod,
                    BookingId = payment.BookingId
                };
                pvms.Add(p);
            }
            var payments = db.Payments.Include(p => p.Booking);
            return View(pvms);
        }

        // GET: Payments/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PaymentModel payment = pcs.GetById((int)id);
            PaymentViewModel p = new PaymentViewModel
            {
                PaymentId = payment.PaymentId,
                Amount = payment.Amount,
                Time = payment.Time,
                DiscountCouponId = payment.DiscountCouponId,
                RemoteTransactionId = payment.RemoteTransactionId,
                PaymentMethod = payment.PaymentMethod,
                BookingId = payment.BookingId
            };
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(p);
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.BookingId = new SelectList(bcs.GetAll(), "BookingId", "Status");
            return View();
        }

        // POST: Payments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PaymentId,Amount,Time,DiscountCouponId,RemoteTransactionId,PaymentMethod,BookingId")] PaymentViewModel payment)
        {
            if (ModelState.IsValid)
            {
                payment.Time = DateTime.Now;
                PaymentModel p = new PaymentModel
                {
                    PaymentId = payment.PaymentId,
                    Amount = payment.Amount,
                    Time = DateTime.Now,
                    DiscountCouponId = payment.DiscountCouponId,
                    RemoteTransactionId = payment.RemoteTransactionId,
                    PaymentMethod = payment.PaymentMethod,
                    BookingId = payment.BookingId
                };
                pcs.Add(p);
                return RedirectToAction("Index");
            }

            ViewBag.BookingId = new SelectList(bcs.GetAll(), "BookingId", "Status", payment.BookingId);
            return View(payment);
        }
    }
}
