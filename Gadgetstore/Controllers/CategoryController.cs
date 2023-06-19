using AspNetCoreHero.ToastNotification.Abstractions;
using Entities;
using IRepository;
using Microsoft.AspNetCore.Mvc;

namespace Gadgetstore.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategory _category;
        private readonly INotyfService _notyf;
        // private readonly INotyfService _notyf;

        public CategoryController(ICategory _category, INotyfService _notyf)
        {
            this._category = _category;
            this._notyf = _notyf;
        }


        [HttpGet]
        public async Task<IActionResult> ListCategory()
        {

            var list = await _category.ListCategory();

            return View(list);

        }


        [HttpGet]
        public IActionResult AddCategory()
        {

            return View();

        }



        [HttpPost]
        public async Task<IActionResult> AddCategory(Category e)
        {
            await _category.AddCategory(e);
            _notyf.Success("Insert Successfull", 5);
            return RedirectToAction("AddCategory");

        }



        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Category e)
        {
            if (ModelState.IsValid)
            {
                _category.EditCategory(e);

            }
            _notyf.Success("Update Successfull", 5);
            return RedirectToAction("ListCategory");

        }

        [HttpGet]
        public async Task<ActionResult> UpdateCategory(int id)
        {
            Category model = await _category.GetIdByCategory(id);
            return View(model);
        }




        [HttpGet]
        public async Task<IActionResult> Delete(int id, bool? saveChangesError)
        {


            Category pro = await _category.GetIdByCategory(id);
            return View(pro);

        }
        [HttpPost, ActionName("Delete")]
        public async Task<ActionResult> Delete(int id)
        {

            if (ModelState.IsValid)
            {
                Category pro = await _category.GetIdByCategory(id);
                _category.deleteCategory(id);
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
