using BooksRental.Models;
//using BooksRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace BooksRental.Controllers
{
    public class CustomersController : Controller
    {
        private ApplicationDbContext _context;
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
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
            var customers = _context.Customers.Include(c => c.MembershipType).ToList();
            return View(customers);
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            return View(customer);
            //Customer c = new Customer();
            //foreach (Customer item in GetCustomers())
            //{
            //    if (item.Id == id)
            //    {
            //        c = item;
            //    }
            //}

            //return View(c);
        }        
    }
}