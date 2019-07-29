using MovieRentalMVCApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MovieRentalMVCApplication;
using MovieRentalMVCApplication.View_Models;
using System.Net.Http;

namespace MovieRentalMVCApplication.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        ApplicationDbContext _context;
        public CustomerController()
        {
            _context = new ApplicationDbContext();
        }
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Customer
        public ActionResult Index()
        {
            //var customers = _context.Customers.Include(c=>c.MembershipType).ToList(); //Eager Loading
            //return View(customers);
            IEnumerable<Customer> customers = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:60272/api/");
                var responseTask = client.GetAsync("customers");
                responseTask.Wait();
                var result = responseTask.Result;
                if(result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IEnumerable<Customer>>();
                    readTask.Wait();
                    customers = readTask.Result;
                }
                else
                {
                    customers = Enumerable.Empty<Customer>();
                    ModelState.AddModelError(string.Empty,"Server Error");
                }
             }
                    return View(customers);
        }
 
        public ActionResult Details(int ?id)
        {
            var customers = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();

            return View(customers);
        }
    
        public ActionResult Edit(int? id)
        {
            var customers = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customers == null)
                return HttpNotFound();
            var viewModel = new NewCustomerViewModel
            {
                Customer = customers,
                MembershipType = _context.MembershipTypes.ToList()
        };
       

            return View("New",viewModel);
        }
        [Authorize(Roles =Roles.Admin)]
        public  ActionResult New()
        {
           
            var membershipTypes = _context.MembershipTypes.ToList();
            var viewModel = new NewCustomerViewModel
            {
                MembershipType = membershipTypes
            };
            return View(viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new NewCustomerViewModel
                {
                    Customer = customer,
                    MembershipType = _context.MembershipTypes.ToList()
                };
                return View("New", viewModel);
            }
            if (customer.Id==0)
            _context.Customers.Add(customer);
           else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                customerInDb.Name = customer.Name;
                customerInDb.BirthDate = customer.BirthDate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSubscribedToNewsLetter = customer.IsSubscribedToNewsLetter;
            }
            _context.SaveChanges();
            return RedirectToAction("Index", "Customer");
        }
        //public ActionResult Delete(int id)
        //{
        //    Customer customer = _context.Customers.Find(id);
        //    _context.Customers.Remove(customer);
        //    _context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}