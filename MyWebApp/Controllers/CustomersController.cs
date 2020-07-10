using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyWebApp.Models;
using MyWebApp.ViewModels;
using System.Data.Entity;

namespace MyWebApp.Controllers
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

        public ActionResult New()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
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
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }
            

            if(customer.ID==0)
                _context.Customers.Add(customer);
            else
            {
                var customerIndb = _context.Customers.Single(c => c.ID == customer.ID);

                customerIndb.Name = customer.Name;
                customerIndb.birthdate = customer.birthdate;
                customerIndb.MembershipTypeID = customer.MembershipTypeID;
                customerIndb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.ID == id);

            if (customer == null)
                return HttpNotFound();

            var viewModel = new NewCustomerViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };

            return View("CustomerForm",viewModel);
        }

        // GET: Customers
        public ViewResult Index()
        {                             
            return View();
        }
        
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(Customer => Customer.MembershipType).SingleOrDefault(Customer => Customer.ID == id);            

            if (customer == null)
                return HttpNotFound();


            return View(customer);
        }

    }
}