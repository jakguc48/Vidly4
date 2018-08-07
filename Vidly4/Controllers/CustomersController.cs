using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly4.Models;

namespace Vidly4.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        [Route("Customers")]
        public ActionResult Index()
        {
            var Customer = GetCustomers();
            return View(Customer);
        }

        [Route("Customers/Details/{id:regex(\\d)}")]
        public ActionResult Details(int id)
        {
            var Customer = GetCustomers().SingleOrDefault(c => c.Id == id);

            if (Customer == null)
            {
                return HttpNotFound();
            }

            return View(Customer);
        }

        private IEnumerable<Customer> GetCustomers()
        {
            return new List<Customer>
            {
                new Customer {Id = 1, Name = "Harold Godfrey"},
                new Customer {Id = 2, Name = "Josh Vicious"}
            };
        }
    }
}