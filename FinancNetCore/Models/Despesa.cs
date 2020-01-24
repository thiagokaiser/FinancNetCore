using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    [Table("despesa")]
    public class Despesa
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
        [Column("valor")]
        public decimal Valor { get; set; }
        [Column("categoriaid")]
        public int CategoriaId { get; set; }        
        public Categoria Categoria { get; set; }
    }
}
