using BookNest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Controllers
{
    public class CustomerController : Controller
    {
        private readonly LibraryContext _context;

        public CustomerController(LibraryContext context)
        {
            _context = context;
        }


        [HttpGet]
        public ActionResult ViewBooks()
        {
            if (HttpContext.Session.GetString("Role") != "Customer")
            {
                ViewBag.Message = "Only customers can view available books.";
                return View("NotAllowed");
            }

            var books = _context.Books.Where(b => b.CopiesAvailable > 0).ToList();
            return View(books);
        }


        [HttpGet]
        public ActionResult BorrowHistory()
        {
            if (HttpContext.Session.GetString("Role") != "Customer")
            {
                ViewBag.Message = "Only customers can view their borrowing history.";
                return View("NotAllowed");
            }

            int userId = (int)HttpContext.Session.GetInt32("UserId");
            var borrowRecords = _context.BorrowRecords.Include(br => br.Book)
                                .Where(br => br.UserId == userId).ToList();
            return View(borrowRecords);
        }
    }


}
