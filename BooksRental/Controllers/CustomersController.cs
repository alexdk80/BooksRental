using BooksRental.Models;
//using BooksRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksRental.Controllers
{
    public class CustomersController : Controller
    {
        // GET: Customers
        public ActionResult Index()
        {
            //var customers = new List<Customer>
            //{
            //    new Customer{Name="John Doe"},
            //    new Customer{Name="Jane Doe"}
            //};
            //var viewModel = new RandomBookViewModel()
            //{
            //    Customers = customers
            //};
            //return View(viewModel);
            var customers = GetCustomers();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            //var customer = GetCustomers().SingleOrDefault(c => c.Id == id);
            //return View(customer);
            Customer c = new Customer();
            foreach (Customer item in GetCustomers())
            {
                if (item.Id == id)
                {
                    c = item;
                }
            }

            return View(c);
        }
        public IEnumerable<Customer> GetCustomers()
        {
            var customers = new List<Customer>
            {
                new Customer { Id = 1, Name = "John Doe" },
                new Customer { Id = 2, Name = "Jane Doe" }
            };
            return customers;
        }
    }
}