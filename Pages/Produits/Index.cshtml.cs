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
        private readonly CartService _cartService;

        public IndexModel(TPPro.Data.DataContext context, CartService cartService)
        {
            _context = context;
            _cartService = cartService;
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
        public IActionResult OnPostAddToCart(int productId)
        {
            var product = _context.Produits.FirstOrDefault(p => p.ProduitID == productId);
            if (product == null)
            {
                return NotFound();
            }

            var cart = _cartService.GetCart();

            cart.Produits.Add(product);
            _cartService.SaveCart(cart);

            return RedirectToPage("/Produits/Index");
        }
    }
}
