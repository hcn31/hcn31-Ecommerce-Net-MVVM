
using System.ComponentModel.DataAnnotations.Schema;

namespace TPPro.Model
{
    public class Produit
    {
        public int ProduitID { get; set; }
        public double Prix { get; set; }
        public String ProduitName { get; set; }
        public int Quantite { get; set; }
        public int CategorieID { get; set; }
        [ForeignKey("CategorieID")]
        public virtual Categorie? Categorie { get; set; }
        public string ImagePath { get; set; }

    }
}
