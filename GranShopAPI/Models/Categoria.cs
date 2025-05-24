// Models/Categoria.cs
namespace GranShopAPI.Models;

public class Categoria
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public List<Produto> Produtos { get; set; }
}