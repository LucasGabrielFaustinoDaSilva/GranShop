using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GranShopAPI.Models;

[Table("Produto")]
public class Produto
{
    [Key]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string Nome { get; set; }

    [Required]
    [StringLength(500)]  
    public string Descricao { get; set; }

    [Required]
    [Range(0, int.MaxValue)]
    [StringLength(100)]
    public int Estoque { get; set; }

    [Required]
    
    
    public decimal ValorCusto { get; set; }
    public decimal ValorVenda { get; set; }
    public bool Destaque { get; set; }

    [Required]
    public int CategoriaId { get; set; }
    [ForeignKey("CategoriaId")]
    public Categoria Categoria { get; set; }
}