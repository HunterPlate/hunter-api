using Dapper;
using hunter_repository.Extensions;
using hunter_repository.Interface;
using hunter_repository.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;

namespace hunter_repository.Repositories
{
    public class RegisterPlatesRepositorie : IRegisterPlatesRepositorie
    {
        private readonly string _connectionString;

        public RegisterPlatesRepositorie(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? string.Empty;
        }

        public async Task<bool> InsertPlates(List<RegisterPlatesModelRepository> plates)
        {
            var result = true;

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = GetQuerys.Insert.InsertPlates;

                        foreach (var plate in plates)
                        {
                            var response = await connection.QueryAsync(query, plate, transaction: transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        return false;
                        throw new Exception(ex.Message);
                    }
                    
                }

                return result;
            }
        }

        public async Task<List<CollectedPlatesModelRepository>> GetPlates()
        {
            var response = new CollectedPlatesModelRepository();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();

                string query = GetQuerys.Get.GetPlates;

                var res = await connection.QueryAsync<CollectedPlatesModelRepository>(query);

                return res.ToList();
            }
        }

        public async Task DeletePlates(List<DeletePlatesModelRepository> plates)
        {
            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string query = GetQuerys.Delete.DeletePlates;

                        foreach (var plate in plates)
                        {
                            var response = await connection.QueryAsync(query, plate, transaction: transaction);
                        }

                        transaction.Commit();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        throw new Exception(ex.Message);
                    }
                }
            }
        }
    }
}
