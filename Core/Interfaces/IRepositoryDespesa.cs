using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IRepositoryDespesa
    {
        Task<IEnumerable<Despesa>> GetDespesasAsync();
        Task<Despesa> GetDespesaAsync(int id);
        Task AddDespesaAsync(Despesa despesa);
        Task DelDespesaAsync(int id);
        Task UpdateDespesaAsync(Despesa despesa);
    }
}
