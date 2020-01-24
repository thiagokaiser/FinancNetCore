using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Core.Services
{
    public class CategoriaService
    {
        private readonly IRepositoryCategoria repository;
        public CategoriaService(IRepositoryCategoria repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            return await repository.GetCategoriasAsync();
        }
        public async Task<Categoria> GetCategoriaAsync(int id)
        {
            return await repository.GetCategoriaAsync(id);
        }
        public async Task AddCategoriaAsync(Categoria categ)
        {
            await repository.AddCategoriaAsync(categ);
        }
        public async Task DelCategoriaAsync(int id)
        {
            await repository.DelCategoriaAsync(id);
        }
        public async Task UpdateCategoriaAsync(Categoria categ)
        {
            await repository.UpdateCategoriaAsync(categ);
        }
    }
}
