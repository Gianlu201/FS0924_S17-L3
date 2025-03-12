using FS0924_S17_L3.Services;
using FS0924_S17_L3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_S17_L3.Controllers
{
    public class LendingController : Controller
    {
        private readonly LendingService _lendingService;

        public LendingController(LendingService lendingService)
        {
            _lendingService = lendingService;
        }

        public async Task<IActionResult> AddLending()
        {
            var booksList = await _lendingService.GetAllAvailableBooksAsync();

            TempData["AvailableBooks"] = booksList;

            var usersList = await _lendingService.GetAllUsersAsync();

            TempData["Users"] = usersList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddLending(AddLendingViewModel addLendingViewModel)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("AddLending");
            }

            var result = await _lendingService.AddLendingAsync(addLendingViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while saving data into database";
            }

            return RedirectToAction("Index", "Admin");
        }

        public async Task<IActionResult> ManageLendings()
        {
            var lendingsList = await _lendingService.GetAllLendingsAsync();

            return View(lendingsList);
        }
    }
}
