using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Web.Http;
using AutoMapper;
using Vidly4.Dtos;
using Vidly4.Models;

namespace Vidly4.Controllers.Api
{
    //180817_0_15:12 tworzenie całego kontrolera
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;
        
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET /api/customers + 180817_4_20:35 zmiany na mapper i dto
        public IEnumerable<CustomerDto> GetCustomers()
        {
            //mappujemy do customerdto, poprzez mapper, i nie używamy () ponieważ nie uruchamiamy metody, tylko delegujemy do niej
            //180819_5_15:21 dodajemy odniesienie do membership type na celu majac dodanie memtype do tabeli w api. tworzymy nowe dto w tym celu
            return _context.Customers.Include(c => c.MembershipType).ToList().Select(Mapper.Map<Customer, CustomerDto>);
        }


        // GET /api/customer/1 + 180817_4_20:35 zmiany na mapper i dto, tutaj nie zwracamy listy jak wyzej wiec select nie dziala
        //trzeba uzyc innej metody nanosimy zmiany w typie zwracanym i w return

        public IHttpActionResult GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(Mapper.Map<Customer, CustomerDto>(customer));
        }

        // POST /api/customer + 180817_4_20:35 tutaj mapujemy dto do domain object
        [HttpPost]
        public IHttpActionResult CreateCustomer(CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            //180817_0_15:12 dodajemy do kontekstu nowego customera

            var customer = Mapper.Map<CustomerDto, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            //180817_4_20:35 mamy jeszcze id wygenerowane przez database dlatego musimy je podać ręcznie

            customerDto.Id = customer.Id;

            //zwracamy cusotmera
            return Created(new Uri(Request.RequestUri + "/" + customer.Id), customerDto);
        }

        // PUT /api/customer/1 + 180817_4_20:35 
        [HttpPut]
        public IHttpActionResult UpdateCustomer(int id, CustomerDto customerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }
            //mapujemy - poxniej automapper
            /*
            customerInDb.Name = customer.Name;
            customerInDb.Birthdate = customer.Birthdate;
            customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            customerInDb.MembershipTypeId = customer.MembershipTypeId;
            */

            //180817_4_20:35 - tutaj mapujemy to co powyżej
            //podajemy dwa argumenty target i source, zeby nasz dbContext był w stanie śledzić zmiany w tym obiekcie
            //obiekty w <> są wyszarzone bo automapper z paramterów umie wywnioskować co jaki typ mają Source i Target. Więc <> można usunąć
            Mapper.Map(customerDto, customerInDb);

            _context.SaveChanges();

            return Ok();
        }

        // DELETE /api/customer/1
        [HttpDelete]
        public IHttpActionResult DeleteCustomer(int id)
        {
            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customerInDb);
            _context.SaveChanges();

            return Ok();
        }

    }
}
