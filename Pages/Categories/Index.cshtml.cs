using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TPPro.Data;
using TPPro.Model;

namespace TPPro.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly TPPro.Data.DataContext _context;

        public IndexModel(TPPro.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Categories != null)
            {
                Categorie = await _context.Categories.ToListAsync();
            }
        }
    }
}
