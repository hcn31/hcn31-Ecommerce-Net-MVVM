using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPPro.Data;
using TPPro.Model;

namespace TPPro.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly TPPro.Data.DataContext _context;

        public CreateModel(TPPro.Data.DataContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Categorie Categorie { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Categories == null || Categorie == null)
            {
                return Page();
            }

            _context.Categories.Add(Categorie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
