using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Tesla.Application.DTOs;
using Tesla.Application.Interfaces;

namespace Tesla.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdutoDTO>>> Get()
        {
            var produtos = await _produtoService.ObterProduto();
            if (produtos == null)
            {
                return NotFound("Produto not found");
            }
            return Ok(produtos);

        }

        [HttpGet("{id}", Name = "ObterProduto")]
        public async Task<ActionResult<ProdutoDTO>> Get(int id)
        {
            var produto = await _produtoService.ObterProdutoPorId(id);
            if (produto == null)
            {
                return NotFound("Produto not found");
            }
            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ProdutoDTO produtoDTO)
        {
            if (produtoDTO == null)
                return BadRequest("Data Invalida");

            await _produtoService.AdicionarProduto(produtoDTO);

            return new CreatedAtRouteResult("ObterProduto", new { id = produtoDTO.Id }, produtoDTO);

        }
        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] ProdutoDTO produtoDTO)
        {
            if (id != produtoDTO.Id)
                return BadRequest("Data invalid");

            if (produtoDTO == null)
                return BadRequest("Data invalid");

            await _produtoService.AtualizarProduto(produtoDTO);

            return Ok(produtoDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var produto = await _produtoService.ObterProdutoPorId(id);
            if (produto == null)
            {
                return NotFound("Produto Not found");
            }
            await _produtoService.Remover(id);

            return Ok(produto);

        }
    }
}
