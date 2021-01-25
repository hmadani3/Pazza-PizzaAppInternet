using System;
namespace PizzaApp.Model
{
    public class Pizza
    {
        //nom,prix,ingredients
        public string Nom { get; set; }
        public int Prix { get; set; }
        public string[] Ingredients { get; set; }
        public string ImageUrl { get; set; }
        public string PrixEuro { get { return Prix + "£"; } }
        public string IndregientsStr { get {  return String.Join(",", Ingredients);} }
        public string Title { get { return Nom.PremiereLettreMaj() ; } }
        public Pizza()
        {
        }
    }
}
