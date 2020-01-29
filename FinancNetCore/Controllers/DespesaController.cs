using Api.ViewModels;
using Core.Models;
using Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    public class DespesaController : Controller
    {
        private readonly DespesaService service;
        private readonly CategoriaService categoriaService;

        public DespesaController(DespesaService service,
                                 CategoriaService categoriaService)
        {
            this.service = service;
            this.categoriaService = categoriaService;
        }
        [HttpGet]
        public async Task<IActionResult> IndexAsync()
        {
            var despesasViewModel = new List<ViewDespesaViewModel>();
            IEnumerable<Despesa> despesas = await service.GetDespesasAsync();
            foreach (var item in despesas)
            {
                var categ = await categoriaService.GetCategoriaAsync(item.CategoriaId);
                despesasViewModel.Add(new ViewDespesaViewModel
                {
                    Id = item.Id,
                    Descricao = item.Descricao,
                    Valor = item.Valor,
                    Categoria = categ.Descricao
                });
            }
            return View(despesasViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> EditDespesaAsync(int id)
        {
            var despesa = await service.GetDespesaAsync(id) ?? new Despesa();
            var categs = await categoriaService.GetCategoriasAsync();
            var categsSelectListItem = new List<SelectListItem>();
            foreach (var item in categs)
            {                
                categsSelectListItem.Add(new SelectListItem {
                    Value = item.Id.ToString() , Text = item.Descricao, Selected = ( item.Id == despesa.CategoriaId)
                });
            }

            var editDespesaViewModel = new EditDespesaViewModel
            {
                Id = despesa.Id,
                Descricao = despesa.Descricao,
                Valor = despesa.Valor,
                Categorias = categsSelectListItem
            };
            ViewData["categoria"] = despesa.CategoriaId;

            return View(editDespesaViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> ViewDespesaAsync(int id)
        {
            var despesa = await service.GetDespesaAsync(id) ?? new Despesa();
            return View(despesa);
        }
        [HttpPost]
        public async Task<IActionResult> SaveDespesaAsync(EditDespesaViewModel despesaViewModel)
        {
            var despesa = new Despesa
            {
                Id = despesaViewModel.Id,
                Descricao = despesaViewModel.Descricao,
                Valor = despesaViewModel.Valor,
                CategoriaId = despesaViewModel.CategSelecionada
            };

            if (despesa.Id > 0)
            {
                await service.UpdateDespesaAsync(despesa);
            }
            else
            {
                await service.AddDespesaAsync(despesa);                
            }
            
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DelDespesaAsync(int id)
        {
            await service.DelDespesaAsync(id);
            return RedirectToAction("Index");
        }
    }
}
