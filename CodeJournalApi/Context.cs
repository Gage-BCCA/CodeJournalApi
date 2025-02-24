using System.Data;
using Dapper;
using Npgsql;
using Microsoft.Extensions.Options;

namespace CodeJournalApi
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly String _connectionString;
        private String _database = "CodeJournal";

        public Context(IConfiguration configuration) 
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("SqlConnection");

        }

        public IDbConnection CreateConnection()
            => new NpgsqlConnection(_connectionString);

        public async Task Init()
        {
            await _initDatabase();
        }

        private async Task _initDatabase()
        {
            // var connection = CreateConnection();
            // var sql = $"IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = '{_database}') CREATE DATABASE [{_database}];";
            // await connection.ExecuteAsync(sql);
        }
    }
}