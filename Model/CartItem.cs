using System.ComponentModel.DataAnnotations.Schema;
using TPPro.Model;

public class CartItem
{

    public List<Produit> Produits { get; set; } // Liste des produits dans le panier

    public CartItem()
    {
        Produits = new List<Produit>();
    }
}
