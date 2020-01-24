using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Models
{
    [Table("categoria")]
    public class Categoria
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("descricao")]
        public string Descricao { get; set; }
    }
}
