namespace API_de_Produtos.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Tipo { get; set; }
        public decimal? PrecoUnitario { get; set; }
    }
}
