using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Tesla.Application.DTOs;
using Tesla.Application.Interfaces;

namespace Tesla.WebUI.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoria = await _categoriaService.ObterCategorias();
            return View(categoria);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoriaDTO categoria)
        {
            if (ModelState.IsValid)
            {
                await _categoriaService.Adicionar(categoria);
                return RedirectToAction(nameof(Index));
                    
            }

            return View(categoria);
        }

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if(id == null) return NotFound();

            var categoriaDTO = await _categoriaService.ObterPorId(id);

            if(categoriaDTO == null) return NotFound();
            
            return View(categoriaDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CategoriaDTO categoriaDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoriaService.Atualizar(categoriaDTO);
                }
                catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(categoriaDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null) return NotFound();

            var categoriaDTO = await _categoriaService.ObterPorId(id);

            if (categoriaDTO == null) return NotFound();

            return View(categoriaDTO);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _categoriaService.Remover(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var categoriaDTo = await _categoriaService.ObterPorId(id);

            if (categoriaDTo == null) return NotFound();

            return View(categoriaDTo);

        }
    }
}
