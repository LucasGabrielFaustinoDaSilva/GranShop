using GranShopAPI.Data;
using GranShopAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GranShopAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProdutosController : ControllerBase
{
    private readonly AppDbContext _db;

    public ProdutosController(AppDbContext db)
    {
        _db = db;
    }

    [HttpGet]
    public async Task<IActionResult> Get()
    {
        var produtos = await _db.Produtos.Include(p => p.Categoria).ToListAsync();
        return Ok(produtos);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(int id)
    {
        var produto = await _db.Produtos.Include(p => p.Categoria).FirstOrDefaultAsync(p => p.Id == id);
        if (produto == null)
            return NotFound();
        return Ok(produto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] Produto produto)
    {
        if (!ModelState.IsValid)
            return BadRequest("Produto informado com problemas");
            
        // Verifica se a categoria existe
        var categoria = await _db.Categorias.FindAsync(produto.CategoriaId);
        if (categoria == null)
            return BadRequest("Categoria não encontrada");
            
        _db.Produtos.Add(produto);
        await _db.SaveChangesAsync();
        return CreatedAtAction(nameof(Get), new { id = produto.Id }, produto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Edit(int id, [FromBody] Produto produto)
    {
        if (!ModelState.IsValid || id != produto.Id)
            return BadRequest("Produto informado com problemas");
            
        // Verifica se o produto existe
        var existingProduto = await _db.Produtos.FindAsync(id);
        if (existingProduto == null)
            return NotFound();
            
        // Verifica se a categoria existe
        var categoria = await _db.Categorias.FindAsync(produto.CategoriaId);
        if (categoria == null)
            return BadRequest("Categoria não encontrada");
            
        _db.Entry(existingProduto).CurrentValues.SetValues(produto);
        await _db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var produto = await _db.Produtos.FindAsync(id);
        if (produto == null)
            return NotFound();
            
        _db.Produtos.Remove(produto);
        await _db.SaveChangesAsync();
        return NoContent();
    }
}