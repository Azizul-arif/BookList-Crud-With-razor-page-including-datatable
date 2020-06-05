using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookList.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BookList.Pages.BookList
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDBContext _db;
        public CreateModel(ApplicationDBContext db)
        {
            _db = db;
        }
        [BindProperty]
        public Book Book { get; set; }
        public void OnGet()
        {

        }

        public async Task <IActionResult>OnPost() //Save data is post method
        {
            if(ModelState.IsValid)
            {
                await _db.Book.AddAsync(Book); // Data will be in queu
                await _db.SaveChangesAsync(); //Data Post to Database
                return RedirectToPage("Index"); //after saving data redirect to index page
            }
            else
            {
                return Page();
            }
        }
    }
}