using BookNest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookNest.Controllers
{
    public class LibrarianController : Controller
    {
        private readonly LibraryContext _context;

        public LibrarianController(LibraryContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("Role") != "Librarian")
            {
                return RedirectToAction("Login", "Account");
            }

            return View();
        }

        [HttpGet]
        public ActionResult ManageBooks()
        {
            if (HttpContext.Session.GetString("Role") != "Librarian")
            {
                return RedirectToAction("Login", "Account");
            }

            var books = _context.Books.ToList();
            return View(books);
        }

        [HttpGet]
        public ActionResult EditBook(int id)
        {
            if (HttpContext.Session.GetString("Role") != "Librarian")
            {
                return RedirectToAction("Login", "Account");
            }

            var book = _context.Books.Find(id);
            return View(book);
        }

        [HttpPost]
        public ActionResult EditBook(Book book)
        {
            if (HttpContext.Session.GetString("Role") != "Librarian")
            {
                return RedirectToAction("Login", "Account");
            }

            _context.Entry(book).State = EntityState.Modified;
            _context.SaveChanges();
            return RedirectToAction("ManageBooks");
        }

        [HttpGet]
        public IActionResult CustomerHistory(int customerId)
        {
     
            var borrowHistory = _context.BorrowRecords
                                        .Include(br => br.Book) 
                                        .Include(br => br.User) 
                                        .Where(br => br.UserId == customerId)
                                        .ToList();

            if (!borrowHistory.Any())
            {
                ViewBag.Message = "No borrowing history available for this customer.";
            }


            return View(borrowHistory);
        }


        [HttpGet]
        public IActionResult CustomerList()
        {
            var customers = _context.Users.Where(u => u.Role == "Customer").ToList();
            return View(customers);
        }

        [HttpGet]
        public IActionResult ViewIssuedBooks()
        {
  
            var issuedBooks = _context.BorrowRecords
                                      .Include(br => br.Book)
                                      .Include(br => br.User)
                                      .Where(br => br.DateReturned == null)
                                      .ToList();

            return View(issuedBooks);
        }

   
        [HttpPost]
        public IActionResult ReturnBook(int borrowRecordId)
        {
        
            var borrowRecord = _context.BorrowRecords
                                       .Include(br => br.Book)
                                       .FirstOrDefault(br => br.BorrowRecordId == borrowRecordId);

            if (borrowRecord == null || borrowRecord.DateReturned != null)
            {
                return NotFound("Invalid borrow record or book already returned.");
            }

      
            borrowRecord.DateReturned = DateTime.Now;
            borrowRecord.Book.CopiesAvailable++;

         
            _context.BorrowRecords.Update(borrowRecord);
            _context.Books.Update(borrowRecord.Book);
            _context.SaveChanges();

            return RedirectToAction("ViewIssuedBooks");
        }

        [HttpGet]
        public IActionResult CreateBook()
        {
            return View();
        }

    
        [HttpPost]
        public IActionResult CreateBook(Book book)
        {
            if (ModelState.IsValid)
            {
             
                book.CopiesAvailable = book.TotalCopies;

                _context.Books.Add(book);
                _context.SaveChanges();
                return RedirectToAction("ManageBooks");
            }
            return View(book);
        }


        [HttpGet]
        public IActionResult IssueBook()
        {
          
            var availableBooks = _context.Books.Where(b => b.CopiesAvailable > 0).ToList();

       
            var customers = _context.Users.Where(u => u.Role == "Customer").ToList();

     
            ViewBag.AvailableBooks = availableBooks;
            ViewBag.Customers = customers;

            return View();
        }

  
        [HttpPost]
        public IActionResult IssueBook(int bookId, int userId)
        {

            var book = _context.Books.Find(bookId);
            var customer = _context.Users.Find(userId);

           
            if (book == null || customer == null || book.CopiesAvailable <= 0)
            {
                ViewBag.ErrorMessage = "Invalid book or customer selection, or no copies available.";

            
                ViewBag.AvailableBooks = _context.Books.Where(b => b.CopiesAvailable > 0).ToList();
                ViewBag.Customers = _context.Users.Where(u => u.Role == "Customer").ToList();

                return View();
            }

         
            var existingBorrowRecord = _context.BorrowRecords
                .Where(br => br.BookId == bookId && br.UserId == userId && br.DateReturned == null)
                .FirstOrDefault();

            if (existingBorrowRecord != null)
            {
           
                ViewBag.ErrorMessage = "Cannot issue the same book twice to the same customer until it is returned.";

               
                ViewBag.AvailableBooks = _context.Books.Where(b => b.CopiesAvailable > 0).ToList();
                ViewBag.Customers = _context.Users.Where(u => u.Role == "Customer").ToList();

                return View();
            }

            
            book.CopiesAvailable--;

          
            var borrowRecord = new BorrowRecord
            {
                BookId = book.BookId,
                UserId = customer.UserId,
                DateIssued = DateTime.Now,
                DateReturned = null
            };

          
            _context.BorrowRecords.Add(borrowRecord);
            _context.Books.Update(book);
            _context.SaveChanges();

            return RedirectToAction("CustomerHistory", new { customerId = customer.UserId });
        }


    }


}
