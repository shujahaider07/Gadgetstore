using IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Gadgetstore.Controllers
{
    using AspNetCoreHero.ToastNotification.Abstractions;
    using DbContextForApplicationLayer;
    using Entities;

    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;

    namespace Gadgetstore.Controllers
    {
        public class ProductController : Controller
        {

            private readonly INotyfService _notyf;
            private readonly ApplicationDbContext db;
            private readonly IProductbusiness productbusiness;

            public ProductController(INotyfService _notyf, ApplicationDbContext db)
            {
                //this._product = _product;
                this._notyf = _notyf;
                this.db = db;
            }

            [HttpGet]
            public async Task<IActionResult> Listproduct()
            {

                var list = await _product.ListProductsVm();

                return View(list);

            }


            [HttpGet]
            public async Task<IActionResult> Addproduct()
            {


                List<Category> categoriesInproduct = db.Categories.Select(x => new Category { Category_id = x.Category_id, Category_Name = x.Category_Name }).AsEnumerable().ToList();
                ViewBag.Category = new SelectList(categoriesInproduct, "Category_id", "Category_Name");


                return View();

            }



            [HttpPost]
            public async Task<IActionResult> Addproduct(Products e)
            {
                await _product.AddProducts(e);
                _notyf.Success("Insert Successfull", 5);
                return RedirectToAction("Addproduct");

            }



            [HttpPost]
            public async Task<IActionResult> Updateproduct(Products e)
            {
                if (ModelState.IsValid)
                {
                    _product.EditProducts(e);

                }
                _notyf.Success("Update Successfull", 5);
                return RedirectToAction("Listproduct");

            }

            [HttpGet]
            public async Task<ActionResult> Updateproduct(int id)
            {
                Products model = await _product.GetIdByProducts(id);
                return View(model);
            }




            [HttpGet]
            public async Task<IActionResult> Delete(int id, bool? saveChangesError)
            {

                Products pro = await _product.GetIdByProducts(id);
                return View(pro);

            }
            [HttpPost, ActionName("Delete")]
            public async Task<ActionResult> Delete(int id)
            {

                if (ModelState.IsValid)
                {
                    Products pro = await _product.GetIdByProducts(id);
                    _product.deleteProducts(id);
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

}
