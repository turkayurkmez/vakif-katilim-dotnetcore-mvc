using BookStore.MVC.Extensions;
using BookStore.MVC.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BookStore.MVC.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly IBookService bookService;

        public ShoppingController(IBookService bookService)
        {
            this.bookService = bookService;
        }

        public IActionResult Index()
        {
            var collection = getCollectionFromSession();

            return View(collection);
        }

        public IActionResult AddToCard(int id)
        {
            //1. sepete eklenen ürünü çek.
            var book = bookService.GetBookForAddToCard(id);

            //Sadece ilk kez sepete kitap eklendiğinde Session oluşmalı. Ardından 
            //daha önce eklenen session kullanılmalı. 
            ShoppingCardCollection shoppingCardCollection = getCollectionFromSession();
            CardItem cardItem = new CardItem() { Book = book, Quantity = 1 };
            shoppingCardCollection.Add(cardItem);
            saveToSession(shoppingCardCollection);

            return Json(new { message = $"{book.Title} isimli kitap sunucuya ulaştı" });

        }



        private ShoppingCardCollection getCollectionFromSession()
        {
            //var serializedString = HttpContext.Session.GetString("basket");
            //if (serializedString == null)
            //{
            //    return new ShoppingCardCollection();
            //}

            //return JsonConvert.DeserializeObject<ShoppingCardCollection>(serializedString);

            return HttpContext.Session.GetJson<ShoppingCardCollection>("basket") ?? new ShoppingCardCollection();
        }

        private void saveToSession(ShoppingCardCollection shoppingCardCollection)
        {
            //var serialized = JsonConvert.SerializeObject(shoppingCardCollection);
            //HttpContext.Session.SetString("basket", serialized);

            HttpContext.Session.SetJson("basket", shoppingCardCollection);

        }
    }
}
