using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;
using System.Web.Mvc;
using Vidly4.Models;
using Vidly4.ViewModels;

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
            //180810_2_23:16 tutaj również zmieniamy odniesienie na kontekst 
            var Customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //180810_2_23:16----------------------------------------------------------------------------------------------------
            if (Customer == null)
            {
                return HttpNotFound();
            }

            return View(Customer);
        }
        //180812_0_14:23 nowa akcja zwracająca view do forms do dodwania nowych customerow
        public ActionResult New()
        {
            //180812_1_17:33Musimy dodać Dataset dla Membersiptypes w Initial model i dodać nowy View model do którego dodamy zarówno Cusotmera jak i Typy
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipTypes = membershipTypes

            };
            return View(viewModel);
        }
        //180812_0_14:23----------------------------------------------------------------------------------------------------

        //180812_2_18:42 dodajemy akcje tworzaca uzytkownika z http post. Dodajemy HttpPost - dobry nawyk to taki, ze akcje które modyfikuja dane nie powinny być dostepne w miejscu, które pobiera dane czyli HttpGet
        //zachodzi model binding - mvc framework jest na tyle zmyślny, ze rozumie powiazanie pól na stronie i wiaże Customer customer z naszym obiektem Modelem
        [HttpPost]
        public ActionResult Create(Customer customer)
        {
            return View();
        }
        //180812_2_18:42 -----------------------------------------------------
    }
}