using BooksRental.Models;
//using BooksRental.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using BooksRental.ViewModels;

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
        public ActionResult NewCustomer()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm",viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if(!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm",viewModel);
            }
            if (customer.Id == 0)
            {
                _context.Customers.Add(customer);
            }
            else
            {
                var customerIsInDatabase = _context.Customers.Single(c => c.Id == customer.Id);
                //TryUpdateModel(customerIsInDatabase,"", new string[]{"Name","Email"});
                //Mapper.Map(customer, customerIsInDatabase);
                customerIsInDatabase.Name = customer.Name;
                customerIsInDatabase.Birthdate = customer.Birthdate;
                customerIsInDatabase.MembershipTypeId = customer.MembershipTypeId;
                customerIsInDatabase.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            
            _context.SaveChanges();
            return RedirectToAction("Index", "Customers");
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
            var customer = _context.Customers.Include(c=>c.MembershipType).SingleOrDefault(c => c.Id == id);
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
        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer==null)
            {
                return HttpNotFound();
            }
            var viewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            return View("CustomerForm", viewModel);
        }
    }
}