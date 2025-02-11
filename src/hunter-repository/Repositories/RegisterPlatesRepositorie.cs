using Dapper;
using hunter_repository.Extensions;
using hunter_repository.Interface;
using hunter_repository.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace hunter_repository.Repositories
{
    public class RegisterPlatesRepositorie : IRegisterPlatesRepositorie
    {
        private readonly string _connectionString;

        public RegisterPlatesRepositorie(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<List<InsertedPlatesResults>> InsertPlatesRepositorie(List<Models.RegisterPlatesRepositorieModel> plates)
        {
            var results = new List<InsertedPlatesResults>();
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = GetQuerys.Insert.InsertPlates;

                        var response = await connection.QueryAsync<InsertedPlatesResults>(query, plates);

                        results = response.ToList();

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                    
                }

                return results;
            }
        }
    }
}
