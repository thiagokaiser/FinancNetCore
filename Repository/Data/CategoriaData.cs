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
    public class CategoriaData : IRepositoryCategoria
    {
        private string connectionString;
        public CategoriaData(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public async Task<IEnumerable<Categoria>> GetCategoriasAsync()
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var categorias = await conexao.QueryAsync<Categoria>("SELECT * FROM Categoria");
                return categorias;
            }
        }
        public async Task<Categoria> GetCategoriaAsync(int id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                try
                {
                    var categoria = await conexao.QueryFirstAsync<Categoria>("SELECT * FROM Categoria WHERE id = @Id", new { Id = id });
                    return categoria;
                }
                catch (Exception)
                {
                    return null;   
                }                
            }
        }
        public async Task AddCategoriaAsync(Categoria categ)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var categoria = await conexao.ExecuteAsync("INSERT INTO Categoria(Descricao) VALUES(@Descricao)", categ);
            }
        }
        public async Task DelCategoriaAsync(int id)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var categoria = await conexao.ExecuteAsync(@"DELETE FROM Categoria                                                          
                                                             WHERE id = @Id", new { Id = id });
            }
        }
        public async Task UpdateCategoriaAsync(Categoria categ)
        {
            using (NpgsqlConnection conexao = new NpgsqlConnection(connectionString))
            {
                var categoria = await conexao.ExecuteAsync(@"UPDATE Categoria SET
                                                             descricao = @Descricao
                                                             WHERE id = @Id", categ);
            }
        }        
    }
}
