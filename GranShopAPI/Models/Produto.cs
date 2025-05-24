// Models/Produto.cs
namespace GranShopAPI.Models;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public int Estoque { get; set; }
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public bool Destaque { get; set; }
    public int CategoriaId { get; set; }
    
    public Categoria Categoria { get; set; }
}