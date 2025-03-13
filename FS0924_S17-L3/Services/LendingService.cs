using FS0924_S17_L3.Data;
using FS0924_S17_L3.Models;
using FS0924_S17_L3.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace FS0924_S17_L3.Services
{
    public class LendingService
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public LendingService(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
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

        public async Task<BooksListViewModel> GetAllAvailableBooksAsync()
        {
            try
            {
                var booksList = new BooksListViewModel();

                booksList.Books = await _context.Books.Where(b => b.Available).ToListAsync();

                return booksList;
            }
            catch
            {
                return new BooksListViewModel() { Books = new List<Book>() };
            }
        }

        public async Task<UsersListViewModel> GetAllUsersAsync()
        {
            try
            {
                var booksList = new UsersListViewModel();

                booksList.Users = await _context.Users.ToListAsync();

                return booksList;
            }
            catch
            {
                return new UsersListViewModel() { Users = new List<User>() };
            }
        }

        public async Task<bool> AddLendingAsync(AddLendingViewModel addLendingViewModel)
        {
            try
            {
                var lending = new Lending()
                {
                    Id = Guid.NewGuid(),
                    IdUser = addLendingViewModel.IdUser,
                    IdBook = addLendingViewModel.IdBook,
                    LendingDate = DateTime.Now,
                    LendingEnd = DateTime.Now.AddDays(7),
                    Active = true,
                };

                _context.Lendings.Add(lending);

                var book = _context.Books.Find(addLendingViewModel.IdBook);

                if (book == null)
                {
                    return false;
                }

                book.Available = false;

                await _emailService.SendEmail("Pinco", book.Title);

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }

        public async Task<LendingsListViewModel> GetAllLendingsAsync()
        {
            try
            {
                var lendingsList = new LendingsListViewModel();

                lendingsList.Lendings = await _context
                    .Lendings.Include(l => l.Book)
                    .Include(l => l.User)
                    .ToListAsync();

                return lendingsList;
            }
            catch
            {
                return new LendingsListViewModel() { Lendings = new List<Lending>() };
            }
        }

        public async Task<bool> ReturnBookAsync(Guid id)
        {
            try
            {
                var lending = await _context.Lendings.FindAsync(id);

                if (lending == null)
                {
                    return false;
                }

                lending.Active = false;

                var book = await _context.Books.FindAsync(lending.IdBook);

                if (book == null)
                {
                    return false;
                }

                book.Available = true;

                return await SaveAsync();
            }
            catch
            {
                return false;
            }
        }
    }
}
