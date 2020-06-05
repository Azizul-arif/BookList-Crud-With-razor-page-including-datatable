using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookList
{
    public class EditModel : PageModel
    {
        private ApplicationDBContext _db;
        public EditModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public async Task OnGet(int id) //public void Onget change to public async Task beacause we use async here
        {

            Book = await _db.Book.FindAsync(id);

        }
        public async Task<IActionResult> OnPost() //OnPost method sync will be IActionResult
        {
            if(ModelState.IsValid)
            {
                var BookFromDb = await _db.Book.FindAsync(Book.Id);
                BookFromDb.Name = Book.Name;
                BookFromDb.Author = Book.Author;
                BookFromDb.ISBN = Book.ISBN;
                await _db.SaveChangesAsync(); //this line will update the value of book object
                return RedirectToPage("Index");
            }
            return RedirectToPage();
        }
    }
}