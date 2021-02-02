using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WizLib_DataAccess.Data;
using WizLib_Models.Models;
using WizLib_Models.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WizLib.Controllers
{
    public class BookController : Controller
    {
        private readonly ApplicationDbContext _db;

        public BookController(ApplicationDbContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<Book> objList = _db.Books.Include(u => u.Publisher).ToList();

            //foreach(var obj in objList)
            //{
            //    //obj.Publisher = _db.Publishers.FirstOrDefault(u => u.Publisher_Id == obj.Publisher_Id);
            //    _db.Entry(obj).Reference(u => u.Publisher).Load();
            //}

            return View(objList);

        }

        public IActionResult Upsert(int? id)
        {

            BookVM obj = new BookVM();

            obj.PublisherList = _db.Publishers.Select(i => new SelectListItem
            {
                Text = i.Name,
                Value = i.Publisher_Id.ToString()
            });

            if (id == null)
            {
                return View(obj);
            }

            obj.Book = _db.Books.FirstOrDefault(u => u.Book_Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(BookVM obj)
        {
            
                if (obj.Book.Book_Id == 0)
                {
                    //this is create
                    _db.Books.Add(obj.Book);
                }

                else
                {
                    //this is update
                    _db.Books.Update(obj.Book);
                }

                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            
        }

        public IActionResult Details(int? id)
        {

            BookVM obj = new BookVM();

            if (id == null)
            {
                return View(obj);
            }

            obj.Book = _db.Books.Include(u => u.BookDetail_Id).FirstOrDefault(u => u.Book_Id == id);

            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(BookVM obj)
        {

            if (obj.Book.BookDetail.BookDetail_Id == 0)
            {
                //this is create
                _db.BookDetails.Add(obj.Book.BookDetail);
                _db.SaveChanges();

                var BookFromDb = _db.Books.FirstOrDefault(u => u.Book_Id == obj.Book.Book_Id);
                BookFromDb.BookDetail_Id = obj.Book.BookDetail.BookDetail_Id;
            }

            else
            {
                //this is update
                _db.BookDetails.Update(obj.Book.BookDetail);
                _db.SaveChanges();
            }

            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }


        public IActionResult Delete(int id)

        {
            var objFromObj = _db.Books.FirstOrDefault(u => u.Book_Id == id);
            _db.Books.Remove(objFromObj);
            _db.SaveChanges();
            return RedirectToAction(nameof(Index));

        }
    }
}
