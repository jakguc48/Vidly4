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
            //180819_4_15:05 wywalamy to customer ponieważ pobieramy dane z naszego api i przekazywanie modelu nie jest już nam potrzebne
            // var Customer = _context.Customers.Include(c => c.MembershipType).ToList();
            //180810_1_19:36----------------------------------------------------------------------------------------------------
            return View();
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
            var viewModel = new CustomerFormViewModel
            {
                MembershipTypes = membershipTypes
                

            };
            return View("CustomerForm", viewModel);
        }
        //180812_0_14:23----------------------------------------------------------------------------------------------------

        //180812_2_18:42 dodajemy akcje tworzaca uzytkownika z http post. Dodajemy HttpPost - dobry nawyk to taki, ze akcje które modyfikuja dane nie powinny być dostepne w miejscu, które pobiera dane czyli HttpGet
        //zachodzi model binding - mvc framework jest na tyle zmyślny, ze rozumie powiazanie pól na stronie i wiaże Customer customer z naszym obiektem Modelem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            //180812_3_18:48 Samo add dodaje ale oznacza jako 'added'. jesli chcemy zatwierdzic zmiany w kontekscie, musimy uzyc funkcji save
            //trzeba nakierowac po edycji z powrotem do odpowiedniej akcji
                //180812_5_19:23 Rozdzielamy na akcje dodania i edycji jesli 0 to tworzony, jesli nie to pobieramy go z bazy danych. jest single bo wiemy ze zwraca, nie zakladamy ze taki nie istnieje przy decyji gdyz jestesmy przekierowanie bezposrednio z klikniecia na customera

            //180815_0_13_57 dodajemy Validacje
            if (!ModelState.IsValid)
            {

                var viewModel = new CustomerFormViewModel(customer)
                {

                    //dodajemy dane które są wprowadzone na stronie, odwołujemy się do zmiennej Customer customer podanej jako parametr akcji Save
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            


                //180815_0_13_57--------------------------------------------------------------------------

                if (customer.Id == 0)
                {
                    _context.Customers.Add(customer);
                }
                else
                {
                    var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                    //180812_5_19:32 ręcznie dodajemy mapowanie obiektów, dzięki temu decydujemy co może być poprawione a co nie
                    customerInDb.Name = customer.Name;
                    customerInDb.Birthdate = customer.Birthdate;
                    customerInDb.MembershipTypeId = customer.MembershipTypeId;
                    customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                    //180812_5_19:32----------------------------------------------
                }

                _context.SaveChanges();
                //180812_3_18:48 --------------------------------------------------------------------------------------------
                return RedirectToAction("Index", "Customers");
            
        }
        //180812_2_18:42 -----------------------------------------------------
        public ActionResult Edit(int id)
        {
            //180812_4_19:01 tworzymy akcje Edit, dobieramy odpowiedniego customera i nadpisujemy standardowy View() zeby nie szukał View 'Edit' tylko używamy 'New'
            // wiemy, że New używa newcustomerviewmodel wiec go tez podajemy
            //zmieniamy nazwe CustomerFormViewModel na CustomerFormViewModel F2
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }

            var viewModel = new CustomerFormViewModel(customer)
            {
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm", viewModel);
        }
    }
}