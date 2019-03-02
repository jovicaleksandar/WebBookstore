using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models;

namespace WebBookStore.Controllers
{
    public class BookstoreController : Controller
    {
        // GET: Bookstore
        public ActionResult Index()
        {
            ViewBag.books = HttpContext.Application["books"];
            return View();
        }

        [HttpGet]
        public ActionResult Add()
        {
            ViewBag.books = HttpContext.Application["books"];
            return View();
        }

        [HttpPost]
        public ActionResult Add(Book book)
        {
            Books books = HttpContext.Application["books"] as Books;

            if (!books.collection.Keys.Contains(book.name))
            {
                books.collection.Add(book.name, book);

                if (!books.genres.Contains(book.genre))
                    books.genres.Add(book.genre);
            }

            HttpContext.Application["books"] = books;

            ViewBag.books = HttpContext.Application["books"];

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            ViewBag.books = HttpContext.Application["books"];

            return View();
        }

        [HttpGet]
        public ActionResult Edit(string name)
        {
            Books books = HttpContext.Application["books"] as Books;

            if (books.collection.Keys.Contains(name))
            {
                ViewBag.books = HttpContext.Application["books"];
                return View(books.collection[name]);
            }
            else
                return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Edit(Book book, string key)
        {
            Books books = HttpContext.Application["books"] as Books;

            if (books.collection.Keys.Contains(key))
            {
                books.collection.Remove(key);
                books.collection.Add(book.name, book);
            }
            else
                books.collection.Add(book.name, book);


            if (!books.genres.Contains(book.genre))
                books.genres.Add(book.genre);

            HttpContext.Application["books"] = books as Books;

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Delete(string name)
        {
            Books books = HttpContext.Application["books"] as Books;

            if (books.collection.Keys.Contains(name))
                books.collection.Remove(name);

            return RedirectToAction("List");
        }
    }
}