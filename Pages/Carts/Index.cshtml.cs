using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TPPro.Pages.Carts
{
    public class IndexModel : PageModel
    {
        private readonly CartService _cartService;

        public IndexModel(CartService cartService)
        {
            _cartService = cartService;
        }

        public CartItem Cart { get; set; }

        public void OnGet()
        {
            Cart = _cartService.GetCart();
        }

        public IActionResult OnPostRemoveFromCart(int productId)
        {
            var cart = _cartService.GetCart();
            cart.Produits.Remove(item: cart.Produits.Where(p => p.ProduitID == productId).First());
            _cartService.SaveCart(cart);
            return RedirectToAction(nameof(Index));
        }
    }
}
