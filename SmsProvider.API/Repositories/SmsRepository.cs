using Dapper;
using SmsProvider.API.Interfaces;
using SmsProvider.API.Models;
using System.Data.SqlClient;

namespace SmsProvider.API.Repositories
{
    public class SmsRepository : ISmsRepository
    {
        private readonly IConfiguration _configuration;

        public SmsRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<bool> CreateAsync(IEnumerable<Sms> entities)
        {
            var sql = "Insert into SMS (Id,Message,PhoneNumber) VALUES (@Id,@Message,@PhoneNumber)";
            foreach (var entity in entities)
            {
                using (var connection = new SqlConnection(_configuration.GetConnectionString("DapperConnection")))
                {
                    connection.Open();
                    var result = await connection.ExecuteAsync(sql, entity);
                    if (result == 0)
                    {
                        throw new Exception($"Sms from {entity.PhoneNumber} insertion failed");
                    }
                }
            }
            return true;
        }
    }
}
