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
    public class AuthorController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AuthorController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Author> objList = _db.Authors.ToList();

            return View(objList);
        }

        public IActionResult Upsert(int? id)
        {

            Author obj = new Author();

            if (id == null)
            {
                return View(obj);
            }

            obj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Author obj)
        {
            if (ModelState.IsValid)
            {
                if (obj.Author_Id == 0)
                {
                    //this is create
                    _db.Authors.Add(obj);
                }

                else
                {
                    //this is update
                    _db.Authors.Update(obj);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(obj);
        }

        public IActionResult Delete(int id)

        {
            var objFromObj = _db.Authors.FirstOrDefault(u => u.Author_Id == id);
            _db.Authors.Remove(objFromObj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
