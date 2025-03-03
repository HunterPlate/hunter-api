using Dapper;
using hunter_repository.Extensions;
using hunter_repository.Interface;
using hunter_repository.Models;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

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

        public async Task<CollectedPlatesModelRepository?> GetPlates(string plate)
        {
            var response = new CollectedPlatesModelRepository();

            using (var connection = new MySqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var param = new
                {
                    plate = plate
                };

                string query = GetQuerys.Get.GetPlates;

                var res = await connection.QueryAsync<CollectedPlatesModelRepository?>(query, param);

                return res.FirstOrDefault();
            }
        }
    }
}
