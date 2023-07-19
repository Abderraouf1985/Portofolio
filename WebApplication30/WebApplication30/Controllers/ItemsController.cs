using Microsoft.AspNetCore.Mvc;
using WebApplication30.Data;
using WebApplication30.Models;

namespace WebApplication30.Controllers
{
    public class ItemsController : Controller
    {





        public ItemsController(AppDbContext db)
        {
            _db = db;
        }
        
        
        
        
        private readonly AppDbContext _db;




        public IActionResult Index()
        {
            IEnumerable<Item> itemsList = _db.Items.ToList();
            return View(itemsList);
        }
        //GET
        public IActionResult New() 
        {
        return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(Item item)
        {
            if (item.Name == "100") 
            {
                ModelState.AddModelError("Name", "NAME CANNOT BE EQUAL 100");
            
            
            }
            if (ModelState.IsValid)
            {
                _db.Items.Add(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been added succesfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(item);

            }



        }


        //GET
        public IActionResult Edit(int? Id)
        {

            if (Id== null || Id==0 )
                    
            {

                return NotFound();     

            }
            var item = _db.Items.Find(Id);
            if(item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Item item)
        { 
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "NAME CANNOT BE EQUAL 100");


            }
            if (ModelState.IsValid)
            {
                _db.Items.Update(item);
                _db.SaveChanges();
                TempData["successData"] = "Item has been updated succesfully";
                return RedirectToAction("Index");

            }
            else
            {
                return View(item);

            }



        }


        //GET
        public IActionResult Delete(int? Id)
        {

            if (Id == null || Id == 0)

            {

                return NotFound();

            }
            var item = _db.Items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }

            return View(item);
        }

        //POST
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteItem(int? Id)
        {
           var item = _db.Items.Find(Id);
            if (item == null) 
            {
                return NotFound();
            }
            _db.Remove(item);    
            _db.SaveChanges();
            TempData["successData"] = "Item has been deleted succesfully";
            return RedirectToAction("Index");

            
         


        }

    }
}
