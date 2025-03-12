using FS0924_S17_L3.Services;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_S17_L3.Controllers
{
    public class BookController : Controller
    {
        private readonly BookService _bookService;

        public BookController(BookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<IActionResult> Index()
        {
            var booksList = await _bookService.GetAllBooksAsync();

            return View(booksList);
        }
    }
}
