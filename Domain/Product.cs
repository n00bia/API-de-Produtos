using API_de_Produtos.Enums;

namespace API_de_Produtos.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public ProductType Type { get; set; }
        public float? Price { get; set; }
    }
}
