using FS0924_S17_L3.Data;
using FS0924_S17_L3.Models;
using FS0924_S17_L3.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FS0924_S17_L3.Services
{
    public class AdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch
            {
                return false;
            }
        }

        public async Task<BooksListViewModel> GetAllBooksAsync()
        {
            try
            {
                var booksList = new BooksListViewModel();

                booksList.Books = await _context.Books.Include(b => b.Genre).ToListAsync();

                return booksList;
            }
            catch
            {
                return new BooksListViewModel() { Books = new List<Book>() };
            }
        }

        public async Task<GenresListViewModel> GetAllGenres()
        {
            try
            {
                var genresList = new GenresListViewModel();

                genresList.Genres = await _context.Genres.ToListAsync();

                return genresList;
            }
            catch
            {
                return new GenresListViewModel() { Genres = new List<Genre>() };
            }
        }

        public async Task<bool> AddBookAsync(AddBookViewModel addBookViewModel)
        {
            try
            {
                var fileName = addBookViewModel.Cover.FileName;

                var path = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "uploads",
                    "images",
                    fileName
                );

                await using (var stream = new FileStream(path, FileMode.Create))
                {
                    await addBookViewModel.Cover.CopyToAsync(stream);
                }

                var webPath = Path.Combine("uploads", "images", fileName);

                var book = new Book()
                {
                    Id = Guid.NewGuid(),
                    Title = addBookViewModel.Title,
                    Author = addBookViewModel.Author,
                    GenreId = addBookViewModel.GenreId,
                    Available = addBookViewModel.Available,
                    Cover = webPath,
                };

                _context.Books.Add(book);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<EditBookViewModel> GetBookByIdAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return new EditBookViewModel();
            }

            var editBook = new EditBookViewModel()
            {
                Id = book.Id,
                Title = book.Title,
                Author = book.Author,
                GenreId = book.GenreId,
                Available = book.Available,
                Cover = null,
            };

            return editBook;
        }

        public async Task<bool> EditBookAsync(EditBookViewModel editBookViewModel)
        {
            try
            {
                var book = await _context.Books.FindAsync(editBookViewModel.Id);

                if (book == null)
                {
                    return false;
                }

                string webPath = "";

                if (editBookViewModel.Cover != null)
                {
                    var fileName = editBookViewModel.Cover.FileName;

                    var path = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot",
                        "uploads",
                        "images",
                        fileName
                    );

                    await using (var stream = new FileStream(path, FileMode.Create))
                    {
                        await editBookViewModel.Cover.CopyToAsync(stream);
                    }

                    webPath = Path.Combine("uploads", "images", fileName);
                }

                if (editBookViewModel.GenreId != null)
                {
                    book.Title = editBookViewModel.Title;
                    book.Author = editBookViewModel.Author;
                    book.Available = editBookViewModel.Available;
                    book.GenreId = (Guid)editBookViewModel.GenreId;

                    if (editBookViewModel.Cover != null)
                    {
                        book.Cover = webPath;
                    }
                }

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteBookByIdAsync(Guid id)
        {
            var book = await _context.Books.FindAsync(id);

            if (book == null)
            {
                return false;
            }

            _context.Books.Remove(book);

            return await SaveAsync();
        }
    }
}
