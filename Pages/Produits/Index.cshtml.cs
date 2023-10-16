using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TPPro.Data;
using TPPro.Model;

namespace TPPro.Pages.Produits
{
    public class IndexModel : PageModel
    {
        private readonly TPPro.Data.DataContext _context;

        public IndexModel(TPPro.Data.DataContext context)
        {
            _context = context;
        }

        public IList<Produit> Produit { get;set; } = default!;
        public async Task OnGetAsync(string searchString)
        {
            if (_context.Produits != null)
            {
              
                var produits = from p in _context.Produits
                               select p;
                if (!string.IsNullOrEmpty(searchString))
                {
                    produits = produits.Where(p => p.ProduitName.Contains(searchString));
                    Produit = await produits.ToListAsync();
                }
                else Produit = await _context.Produits.Include(p => p.Categorie).ToListAsync();
            }
           
        }
    }
}
