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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> Get()
        {
            var categorias = await _categoriaService.ObterCategorias();
            if(categorias == null)
            {
                return NotFound("Categoria not found");
            }
            return Ok(categorias);

        }

        [HttpGet("{id:int}", Name = "ObterCategoria")]
        public async Task<ActionResult<CategoriaDTO>> Get(int id)
        {
            var categoria = await _categoriaService.ObterPorId(id);
            if(categoria == null)
            {
                return NotFound("Categoria not found");
            }
            return Ok(categoria);
        }


        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CategoriaDTO categoriaDTO)
        {
            if(categoriaDTO == null)
                return BadRequest("Data Invalida");
            
            await _categoriaService.Adicionar(categoriaDTO);

            return new CreatedAtRouteResult("ObterCategoria", new { id = categoriaDTO.Id }, categoriaDTO);

        }

        [HttpPut]
        public async Task<ActionResult> Put(int id, [FromBody] CategoriaDTO categoriaDTO)
        {
            if (id != categoriaDTO.Id)
                return BadRequest();

            if (categoriaDTO == null)
                return BadRequest();

            await _categoriaService.Atualizar(categoriaDTO);
            
            return Ok(categoriaDTO);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<CategoriaDTO>> Delete(int id)
        {
            var categoria = await _categoriaService.ObterPorId(id);
            if (categoria == null)
            {
                return NotFound("Categoria Not found");
            }
           await _categoriaService.Remover(id);

            return Ok(categoria);

        }
    }
}
