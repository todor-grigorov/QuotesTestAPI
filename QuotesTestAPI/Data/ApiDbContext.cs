using Microsoft.EntityFrameworkCore;
using QuotesTestAPI.Models;

namespace QuotesTestAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options) 
        {
            
        }

        public DbSet<Quote> Quotes { get; set; }
    }
}
