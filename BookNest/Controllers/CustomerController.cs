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
        public ActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Customer")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ViewBooks()
        {
            if (HttpContext.Session.GetString("Role") != "Customer")
            {
                return RedirectToAction("Login", "Account");
            }

            var books = _context.Books.Where(b => b.CopiesAvailable > 0).ToList();

            return View(books);
        }


        [HttpGet]
        public ActionResult BorrowHistory()
        {
            if (HttpContext.Session.GetString("Role") != "Customer")
            {
                return RedirectToAction("Login", "Account");
            }

            int userId = (int)HttpContext.Session.GetInt32("UserId");
            var borrowRecords = _context.BorrowRecords.Include(br => br.Book)
                                .Where(br => br.UserId == userId).ToList();
            return View(borrowRecords);
        }
    }


}
