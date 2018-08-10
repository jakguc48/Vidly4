using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly4.Models;

namespace Vidly4.Controllers
{
    public class CustomersController : Controller
    {
        //180810_0 18:43 Dodajemy kontekst, żeby nie używać hardcoded data tylko odwoływać się w metodzie do bazy danych.
        //dodajemy również nadpisanie metody dispose podstawowego kontrolera

        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }
         
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //180810_0 18:43----------------------------------------------------------------------------------------------------

        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            //180810_1_18:51 tutaj zmieniamy na odniesienie do kontekstu zamiast wewnętrznej metody. Odniesienie do db
            //dodajemy do odniesienia TOLIST żeby od razu ładował całość a nie pojedynczo podczas iteracji
                //180810_1_19:36 dodajemy include, zeby w podowaniu zawrzec rowniez inna tabele, aby sie do niej odwlolac potem
            var Customer = _context.Customers.Include(c => c.MembershipType).ToList();
            //180810_1_19:36----------------------------------------------------------------------------------------------------
            return View(Customer);
            //180810_1_18:51----------------------------------------------------------------------------------------------------
        }

        [Route("Customers/Details/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            //180810_2_18:55 tutaj również zmieniamy odniesienie na kontekst 
            var Customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            //180810_2_18:55----------------------------------------------------------------------------------------------------
            if (Customer == null)
            {
                return HttpNotFound();
            }

            return View(Customer);
        }

        
    }
}