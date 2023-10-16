using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TPPro.Data;
using TPPro.Model;

namespace TPPro.Pages.Produits
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
        ViewData["CategorieID"] = new SelectList(_context.Categories, "CategorieId", "CategorieId");
            return Page();
        }

        [BindProperty]
        public Produit Produit { get; set; } = default!;

        [BindProperty]
        public IFormFile ImageFile { get; set; }
        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            var fileName = Path.GetFileName(ImageFile.FileName);
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", fileName);
            using (var fileStream = new FileStream(imagePath, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }
            Produit.ImagePath = "images/" + fileName;
            await Console.Out.WriteLineAsync("here");
            _context.Produits.Add(Produit);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
