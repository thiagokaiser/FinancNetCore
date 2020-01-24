using Core.Interfaces;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace Core.Services
{
    public class DespesaService
    {
        private readonly IRepositoryDespesa repository;
        public DespesaService(IRepositoryDespesa repository)
        {
            this.repository = repository;
        }
        public async Task<IEnumerable<Despesa>> GetDespesasAsync()
        {
            return await repository.GetDespesasAsync();
        }
        public async Task<Despesa> GetDespesaAsync(int id)
        {
            return await repository.GetDespesaAsync(id);
        }
        public async Task AddDespesaAsync(Despesa despesa)
        {
            await repository.AddDespesaAsync(despesa);
        }
        public async Task DelDespesaAsync(int id)
        {
            await repository.DelDespesaAsync(id);
        }
        public async Task UpdateDespesaAsync(Despesa despesa)
        {
            await repository.UpdateDespesaAsync(despesa);
        }
    }
}
