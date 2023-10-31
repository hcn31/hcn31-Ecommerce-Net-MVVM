using Microsoft.AspNetCore.Http;
using System.Text.Json;

public class CartService
{
    private readonly IHttpContextAccessor _httpContextAccessor;

    public CartService(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }

    public CartItem GetCart()
    {
        var session = _httpContextAccessor.HttpContext.Session;
        string cartJson = session.GetString("Cart");
        if (cartJson != null)
        {
            return JsonSerializer.Deserialize<CartItem>(cartJson);
        }

        return new CartItem();
    }

    public void SaveCart(CartItem cart)
    {
        var session = _httpContextAccessor.HttpContext.Session;
        session.SetString("Cart", JsonSerializer.Serialize(cart));
    }
}