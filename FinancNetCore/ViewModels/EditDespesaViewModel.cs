using Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class EditDespesaViewModel
    {
        public int Id { get; set; }
        public string Descricao { get; set; }        
        public decimal Valor { get; set; }
        public int CategSelecionada { get; set; }
        public List<SelectListItem> Categorias { get; set; }        
        
    }
}
