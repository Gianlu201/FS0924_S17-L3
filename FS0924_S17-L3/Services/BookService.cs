using FS0924_S17_L3.Data;
using FS0924_S17_L3.Models;
using FS0924_S17_L3.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FS0924_S17_L3.Services
{
    public class BookService
    {
        private readonly ApplicationDbContext _context;

        public BookService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BooksListViewModel> GetAllBooksAsync()
        {
            try
            {
                var booksList = new BooksListViewModel();

                booksList.Books = await _context.Books.ToListAsync();

                return booksList;
            }
            catch
            {
                return new BooksListViewModel() { Books = new List<Book>() };
            }
        }
    }
}
