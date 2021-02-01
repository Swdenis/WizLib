using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WizLib_DataAccess.Data;
using WizLib_Models.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WizLib.Controllers
{
    public class PublisherController : Controller
    {
        private readonly ApplicationDbContext _db;

        public PublisherController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Publisher> objList = _db.Publishers.ToList();

            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {

            Publisher obj = new Publisher();

            if (id == null)
            {
                return View(obj);
            }

            obj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Publisher obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Publisher_Id == 0)
                {
                    //this is create
                    _db.Publishers.Add(obj);
                }

                else
                {
                    //this is update
                    _db.Publishers.Update(obj);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Delete(int id)

        {
            var objFromObj = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == id);
            _db.Publishers.Remove(objFromObj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
