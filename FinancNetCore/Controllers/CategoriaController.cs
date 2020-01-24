using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    public class CategoriaController : Controller
    {
        private readonly CategoriaService categoriaService;

        public CategoriaController(CategoriaService categoriaService)
        {
            this.categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<Categoria> categorias = await categoriaService.GetCategoriasAsync();
            return View(categorias);
        }
        [HttpGet]
        public async Task<IActionResult> EditCategoriaAsync(int id)
        {
            var categ = await categoriaService.GetCategoriaAsync(id) ?? new Categoria();
            return View(categ);
        }
        [HttpGet]
        public async Task<IActionResult> ViewCategoriaAsync(int id)
        {
            var categ = await categoriaService.GetCategoriaAsync(id) ?? new Categoria();
            return View(categ);
        }
        [HttpPost]
        public async Task<IActionResult> SaveCategoriaAsync(Categoria categ)
        {
            if (categ.Id > 0)
            {
                await categoriaService.UpdateCategoriaAsync(categ);
            }
            else
            {
                await categoriaService.AddCategoriaAsync(categ);                
            }
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DelCategoriaAsync(int id)
        {
            await categoriaService.DelCategoriaAsync(id);
            return RedirectToAction("Index");
        }
    }
}
