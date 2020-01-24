using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.ViewModels
{
    public class ViewDespesaViewModel
    {        
        public int Id { get; set; }
        public string Descricao { get; set; }        
        public decimal Valor { get; set; }                
        public string Categoria { get; set; }
    }
}
