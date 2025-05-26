using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using SmsHub.Domain.Features.Logging.Entities;
using SmsHub.Domain.Features.Logging.MediatorDtos.Commands.Update;

namespace SmsHub.Persistence.Features.Logging.Raw
{
    public class SqlLogger
    {
        private readonly string _connectionString;
        //private readonly ILogger<SqlLogger> _logger;

        public SqlLogger(IConfiguration config
            //, ILogger<SqlLogger> logger
            )
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
            //_logger = logger;
        }

        public async Task<long> InsertHttpLogAsync(HttpLog log)
        {
            const string sql = @"
            INSERT INTO HttpLog (
                Method, Url, RequestHeaders, RequestBody, RequestDateTime
            ) 
            OUTPUT INSERTED.Id
            VALUES (
                @Method, @Url, @RequestHeaders, @RequestBody, @RequestDateTime
            )";

            try
            {
                await using var connection = new SqlConnection(_connectionString);
                await using var command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Method", log.Method);
                command.Parameters.AddWithValue("@Url", log.Url);
                command.Parameters.AddWithValue("@RequestHeaders", (object)log.RequestHeaders ?? DBNull.Value);
                command.Parameters.AddWithValue("@RequestBody", (object)log.RequestBody ?? DBNull.Value);
                command.Parameters.AddWithValue("@RequestDateTime", log.RequestDateTime);

                await connection.OpenAsync();
                return (long)await command.ExecuteScalarAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Failed to insert HTTP log");
                throw;
            }
        }

        public async Task UpdateHttpLogAsync(long logId, HttpLogUpdate update)
        {
            const string sql = @"
            UPDATE HttpLog SET
                StatusCode = @StatusCode,
                ReasonPhrase = @ReasonPhrase,
                ResponseHeaders = @ResponseHeaders,
                ResponseBody = @ResponseBody,
                Duration = @Duration
            WHERE Id = @Id";

            try
            {
                await using var connection = new SqlConnection(_connectionString);
                await using var command = new SqlCommand(sql, connection);

                command.Parameters.AddWithValue("@Id", logId);
                command.Parameters.AddWithValue("@StatusCode", update.StatusCode);
                command.Parameters.AddWithValue("@ReasonPhrase", (object)update.ReasonPhrase ?? DBNull.Value);
                command.Parameters.AddWithValue("@ResponseHeaders", (object)update.ResponseHeaders ?? DBNull.Value);
                command.Parameters.AddWithValue("@ResponseBody", (object)update.ResponseBody ?? DBNull.Value);
                command.Parameters.AddWithValue("@Duration", update.Duration);

                await connection.OpenAsync();
                await command.ExecuteNonQueryAsync();
            }
            catch (Exception ex)
            {
                //_logger.LogError(ex, "Failed to update HTTP log");
                throw;
            }
        }
    }
}
