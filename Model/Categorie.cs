namespace TPPro.Model
{
    public class Categorie
    {
        public int CategorieId { get; set; }
        public string CategorieNom { get; set; }

        // Navigation property to represent the one-to-many relationship
        public virtual ICollection<Produit>? Produits { get; set;}
    }
}
