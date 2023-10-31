using Microsoft.AspNetCore.Cors.Infrastructure;
using Newtonsoft.Json;
using System.Text.Json;

namespace TPPro.Model
{
    public static class SessionExtensions
    {
        public static void SetCartService(this ISession session, CartItem cart)
        {
            string cartServiceJson = JsonConvert.SerializeObject(cart);
            session.SetString("CartService", cartServiceJson);
        }

        public static CartItem GetCartService(this ISession session)
        {
            string cartServiceJson = session.GetString("CartService");
            if (cartServiceJson != null)
            {
                return JsonConvert.DeserializeObject<CartItem>(cartServiceJson);
            }
            return new CartItem();// Return  if the object is not found in session
        }
    }
}