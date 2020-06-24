using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using QuanLiSach.Models;
using System.Web.UI.WebControls;
using System.Data.Entity.Infrastructure;

namespace QuanLiSach.Controllers
{
    public class BookController : Controller
    {

        // GET: Book
        public ActionResult ListBook()
        {
            var books = new List<string>();
            books.Add("HTML5 & CSS3 The Complete Manual - Author Name Book 1");
            books.Add("HTML5 & CSS Responsive web Design cookbook - Author Name Book 2");
            books.Add("Professional ASP.NET MVC5 - Author Name Book 3");
            ViewBag.Books = books;
            return View();
        }

        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual","Author Name Book 1","/Content/Images/bookcover1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/bookcover2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5","Author Name Book 3", "/Content/Images/bookcover3.jpg"));
            return View(books);
        }
        
      
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/Images/bookcover1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/bookcover2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/bookcover3.jpg"));
            Book book = new Book();
            foreach(Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [HttpPost, ActionName("EditBook")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id, string Title, string Author, string Image_Cover)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/Images/bookcover1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/bookcover2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/bookcover3.jpg"));
            Book book = new Book();
            if (book == null)
            {
                return HttpNotFound();
            }
            foreach(Book b in books)
            {
                if(b.Id == id)
                {
                    b.Title = Title;
                    b.Author = Author;
                    b.Image_Cover = Image_Cover;
                    break;
                }
            }
            return View("ListBookModel",books);
        }

        public ActionResult CreateBook()
        {
            return View();
        }

        [HttpPost, ActionName("CreateBook")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateBook([Bind(Include ="Id, Title, Author, Image_Cover")]Book book)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5 & CSS3 The Complete Manual", "Author Name Book 1", "/Content/Images/bookcover1.jpg"));
            books.Add(new Book(2, "HTML5 & CSS Responsive web Design cookbook", "Author Name Book 2", "/Content/Images/bookcover2.jpg"));
            books.Add(new Book(3, "Professional ASP.NET MVC5", "Author Name Book 3", "/Content/Images/bookcover3.jpg"));
            try
            {
                if (ModelState.IsValid)
                {
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error Save Data");
            }
            return View("ListBookModel", books);
        }
    }
}