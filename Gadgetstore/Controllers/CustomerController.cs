using Entities;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using AspNetCoreHero.ToastNotification.Abstractions;
using EntitiesViewModels;

namespace Gadgetstore.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomer _Customer;
        private readonly INotyfService _notyf;

        public CustomerController(ICustomer _Customer, INotyfService _notyf)
        {
            this._Customer = _Customer;
            this._notyf = _notyf;
        }


        [HttpGet]
        public async Task<IActionResult> ListCustomer()
        {

            var list = await _Customer.ListCustomer();

            return View(list);

        }


        [HttpGet]
        public IActionResult AddCustomer()
        {

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> AddCustomer(CustomerVM e)
        {

            await _Customer.AddCustomer(e);
            _notyf.Success("Insert Successfull", 5);
            return RedirectToAction("AddCustomer");

        }



        [HttpPost]
        public async Task<IActionResult> UpdateCustomer(Customer e)
        {
            if (ModelState.IsValid)
            {
                 _Customer.EditCustomer(e);

            }
            _notyf.Success("Update Successfull", 5);
            return RedirectToAction("ListCustomer");

        }

        [HttpGet]
        public async Task<ActionResult> UpdateCustomer(int id)
        {
            Customer model = await _Customer.GetIdByCustomer(id);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {


            Customer pro = await _Customer.GetIdByCustomer(id);
            return View(pro);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Customer pro = await _Customer.GetIdByCustomer(id);
                _Customer.deleteCustomer(id);
                _notyf.Success("Delete Successfull", 5);
                return RedirectToAction("Listproduct");
            }
            else
            {
                return RedirectToAction("Delete");
            }


        }




    }
}
