using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Models;
using Npgsql;
using Dapper;

namespace Repository.Data
{
    public class DespesaData : IRepositoryDespesa
    {
        private string connectionString;
        public DespesaData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<IEnumerable<Despesa>> GetDespesasAsync()
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var despesas = await conexao.QueryAsync<Despesa>("SELECT * FROM Despesa ORDER BY id");
                return despesas;
            }
        }
        public async Task<Despesa> GetDespesaAsync(int id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                try
                {
                    var despesa = await conexao.QueryFirstAsync<Despesa>("SELECT * FROM Despesa WHERE id = @Id", new { Id = id });
                    return despesa;
                }
                catch (Exception)
                {
                    return null;   
                }                
            }
        }
        public async Task AddDespesaAsync(Despesa despesa)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var desp = await conexao.ExecuteAsync("INSERT INTO Despesa(descricao,valor,categoriaid) VALUES(@Descricao,@Valor,@CategoriaId)", despesa);
            }
        }
        public async Task DelDespesaAsync(int id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var despesa = await conexao.ExecuteAsync(@"DELETE FROM Despesa                                                          
                                                             WHERE id = @Id", new { Id = id });
            }
        }
        public async Task UpdateDespesaAsync(Despesa despesa)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var desp = await conexao.ExecuteAsync(@"UPDATE Despesa SET
                                                             descricao   = @Descricao,
                                                             valor       = @Valor,
                                                             categoriaid = @CategoriaId
                                                             WHERE id = @Id", despesa);
            }
        }        
    }
}
