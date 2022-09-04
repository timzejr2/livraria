using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using livrariaAPIs.Context;
using livrariaAPIs.Models;
using Microsoft.EntityFrameworkCore;

namespace livrariaAPIs.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class produtoController : ControllerBase
    {
        private readonly ProjectContext _context;
        public produtoController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet("Listar")]
        public async Task<ActionResult<IEnumerable<Produto>>> Listar()
        {
            return await _context.Produtos.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var produto = await _context.Produtos.FindAsync(id);

            if(produto == null) return NotFound();

            return Ok(produto);
        }

        [HttpGet("ObterPorNome/{nome}")]
        public async Task<IActionResult> ObterPorNome(string nome)
        {
            var produto = await _context.Produtos.Where(x => x.Nome == nome).ToListAsync();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar(Produto produto)
        {
            await _context.AddAsync(produto);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(ObterPorId), new { id = produto.Id }, produto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, Produto produto)
        {
            var produtoBanco = await _context.Produtos.FindAsync(id);

            if(produto == null) return NotFound();

            produtoBanco.Nome = produto.Nome;
            produtoBanco.Preco = produto.Preco;
            produtoBanco.Quant = produto.Quant;
            produtoBanco.Img = produto.Img;

            _context.Produtos.Update(produtoBanco);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete("id")]
        public async Task<IActionResult> Deletar(int id)
        {
            var produtoBanco = await _context.Produtos.FindAsync(id);

            if(produtoBanco == null) return NotFound();

            _context.Produtos.Remove(produtoBanco);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}