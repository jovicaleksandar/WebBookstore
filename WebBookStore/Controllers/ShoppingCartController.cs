using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBookStore.Models;

namespace WebBookStore.Controllers
{
    public class ShoppingCartController : Controller
    {
        // GET: ShoppingCart
        public ActionResult Index()
        {
            ShoppingCart shoppingCart = Session["cart"] as ShoppingCart;

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                Session["cart"] = shoppingCart;
            }

            ViewBag.cart = shoppingCart;

            return View();
        }

        [HttpPost]
        public ActionResult Add(string name, int count)
        {
            Books books = HttpContext.Application["books"] as Books;
            ShoppingCart shoppingCart = Session["cart"] as ShoppingCart;

            if (shoppingCart == null)
            {
                shoppingCart = new ShoppingCart();
                Session["cart"] = shoppingCart;
            }

            Book book = books.collection[name];
            ShoppingCartItem item = new ShoppingCartItem(book, count);

            shoppingCart.AddItem(item);

            ViewBag.cart = shoppingCart;

            return RedirectToAction("Index");
        }
    }
}