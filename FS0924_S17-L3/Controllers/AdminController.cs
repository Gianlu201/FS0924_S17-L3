﻿using System.Threading.Tasks;
using FS0924_S17_L3.Services;
using FS0924_S17_L3.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace FS0924_S17_L3.Controllers
{
    public class AdminController : Controller
    {
        private readonly AdminService _adminService;

        public AdminController(AdminService adminService)
        {
            _adminService = adminService;
        }

        public async Task<IActionResult> Index()
        {
            var booksList = await _adminService.GetAllBooksAsync();

            return View(booksList);
        }

        public async Task<IActionResult> Add()
        {
            var genresList = await _adminService.GetAllGenres();

            ViewData["Genres"] = genresList;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddBookViewModel addBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error while saving data into database";
                return RedirectToAction("Index");
            }

            var result = await _adminService.AddBookAsync(addBookViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while saving data into database";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Edit/{id:guid}")]
        public async Task<IActionResult> Edit(Guid id)
        {
            var book = await _adminService.GetBookByIdAsync(id);

            if (book.Title == null)
            {
                return RedirectToAction("Index");
            }

            var genresList = await _adminService.GetAllGenres();

            ViewData["Genres"] = genresList;

            return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditBookViewModel editBookViewModel)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Error while editing data on database";
                return RedirectToAction("Index");
            }

            var result = await _adminService.EditBookAsync(editBookViewModel);

            if (!result)
            {
                TempData["Error"] = "Error while saving data into database";
            }

            return RedirectToAction("Index");
        }

        [HttpGet("Admin/Delete/{id:guid}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await _adminService.DeleteBookByIdAsync(id);

            if (!result)
            {
                TempData["Error"] = "Error while deleting entity from database";
            }

            return RedirectToAction("Index");
        }
    }
}
