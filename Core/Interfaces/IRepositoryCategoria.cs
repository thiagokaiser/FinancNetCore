using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepositoryCategoria
    {
        Task<IEnumerable<Categoria>> GetCategoriasAsync();
        Task<Categoria> GetCategoriaAsync(int id);
        Task AddCategoriaAsync(Categoria categ);
        Task DelCategoriaAsync(int id);
        Task UpdateCategoriaAsync(Categoria categ);
    }
}
