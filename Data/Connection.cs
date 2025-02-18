using Backend.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using Backend.Models;

namespace Backend.Data
{
    public class Connection : IConnection
    {
        private readonly AppDbContext _context;

        public Connection(AppDbContext context)
        {
            _context = context;
        }

        public AppDbContext GetContext()
        {
            return _context;
        }

        public static string GetConnectionString()
        {
            string DB_HOST = Environment.GetEnvironmentVariable("DB_HOST") ?? "localhost";
            string DB_PORT = Environment.GetEnvironmentVariable("DB_PORT") ?? "5432";
            string DB_NAME = Environment.GetEnvironmentVariable("DB_NAME") ?? "your_database";
            string DB_USERNAME = Environment.GetEnvironmentVariable("DB_USERNAME") ?? "your_user";
            string DB_PASSWORD = Environment.GetEnvironmentVariable("DB_PASSWORD") ?? "your_password";

            return $"Host={DB_HOST};Port={DB_PORT};Database={DB_NAME};Username={DB_USERNAME};Password={DB_PASSWORD}";
        }
    }
}
