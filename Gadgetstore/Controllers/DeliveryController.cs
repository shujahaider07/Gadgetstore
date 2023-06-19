using AspNetCoreHero.ToastNotification.Abstractions;
using DbContextForApplicationLayer;
using Entities;
using IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.IO.Pipelines;

namespace Gadgetstore.Controllers
{
    public class DeliveryController : Controller
    {
        private readonly IDeliveries _delivery;
        private readonly INotyfService _notyf;
        private readonly ApplicationDbContext _db;


        public DeliveryController(IDeliveries _delivery, INotyfService _notyf, ApplicationDbContext _db)
        {
            this._delivery = _delivery;
            this._notyf = _notyf;
            this._db = _db;
        }


        [HttpGet]
        public async Task<IActionResult> ListDelivery()
        {

            var list = await _delivery.ListDeliveriesVm();

            return View(list);

        }


        [HttpGet]
        public IActionResult AddDelivery()
        {

            List<Customer> customers = _db.Customers.Select(x => new Customer { Id = x.Id, First_Name = x.First_Name }).AsEnumerable().ToList();
             ViewBag.CustomerName = new SelectList(customers,"Id","First_Name");


            return View();

        }



        [HttpPost]
        public async Task<IActionResult> AddDelivery(Deliveries e)
        {
            await _delivery.AddDeliveries(e);
            _notyf.Success("Insert Successfull", 5);
            return RedirectToAction("AddDelivery");

        }



        [HttpPost]
        public async Task<IActionResult> UpdateDelivery(Deliveries e)
        {
            if (ModelState.IsValid)
            {
                _delivery.EditDeliveries(e);

            }
            _notyf.Success("Update Successfull", 5);
            return RedirectToAction("ListDelivery");

        }

        [HttpGet]
        public async Task<ActionResult> UpdateCategory(int id)
        {
            Deliveries model = await _delivery.GetIdByDeliveries(id);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {


            Deliveries pro = await _delivery.GetIdByDeliveries(id);
            return View(pro);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Deliveries pro = await _delivery.GetIdByDeliveries(id);
                _delivery.deleteDeliveries(id);
                _notyf.Success("Delete Successfull", 5);
                return RedirectToAction("ListDelivery");
            }
            else
            {
                return RedirectToAction("Delete");
            }


        }





    }
}
