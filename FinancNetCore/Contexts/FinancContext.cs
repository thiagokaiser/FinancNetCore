using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Api.Contexts
{
    public class FinancContext: DbContext
    {
        public FinancContext(DbContextOptions<FinancContext> options) : base(options)
        {
        }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Despesa> Despesa { get; set; }
    }
}
