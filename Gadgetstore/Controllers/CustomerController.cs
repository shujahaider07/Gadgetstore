using AspNetCoreHero.ToastNotification.Abstractions;
using DbContextForApplicationLayer;
using Entities;
using EntitiesViewModels;
using Gadgetstore.BusinessInterface;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Gadgetstore.Controllers
{
    public class CustomerController : Controller
    {
      //  private readonly ICustomerRepo _Customer;
        private readonly ICustomer _CustomerBusiness;
        private readonly ApplicationDbContext db;
        private readonly INotyfService _notyf;

        public CustomerController(ApplicationDbContext db,ICustomer _CustomerBusiness, INotyfService _notyf)
        {
            this._CustomerBusiness = _CustomerBusiness;
            this._notyf = _notyf;
            this.db = db;
        }


        [HttpGet]
        public async Task<IActionResult> ListCustomer()
        {

            var list = _CustomerBusiness.GetAllCustomer();

            return View(list);

        }


        [HttpGet]
        public IActionResult AddCustomer()
        {
            //Creating the List of SelectListItem, this list you can bind from the database.
            List<SelectListItem> Gender = new()
            {
                new SelectListItem { Value = "1", Text = "Male" },
                new SelectListItem { Value = "2", Text = "Female" },
              
            };

            //assigning SelectListItem to view Bag
            ViewBag.cities = Gender;
            return View();
            

        }



        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerVM e)
        {
            try
            {
                _CustomerBusiness.AddCustomer(e);

                _notyf.Success("Insert Successfull", 5);
                return RedirectToAction("ListCustomer");


            }
            catch (Exception)
            {

                throw;
            }

           


        }



        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer e)
        {
            if (ModelState.IsValid)
            {
                _CustomerBusiness.UpdateCustomer(e);

            }
            _notyf.Success("Update Successfull", 5);
            return RedirectToAction("ListCustomer");

        }

        [HttpGet]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            Customer model = _CustomerBusiness.GetAllCustomerById(id);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {


            _CustomerBusiness.DeleteCustomer(id);
            return View();

        }

        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(CustomerVM customer)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _CustomerBusiness.DeleteCustomer(customer.Id);
                    //  _Customer.deleteCustomer();
                    _notyf.Success("Delete Successfull", 5);


                }

            }
            catch (Exception)
            {

                throw;
            }


            return RedirectToAction("ListCustomer");



        }




    }
}
