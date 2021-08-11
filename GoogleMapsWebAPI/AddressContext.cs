using GoogleMapsWebAPI.Models;
using GoogleMapsWebAPI.Models.Configuration;
using Microsoft.EntityFrameworkCore;

namespace GoogleMapsWebAPI
{
    public class AddressContext : DbContext
    {
        EFConfiguration Config { get; } 
        
        public DbSet<AddressOutputModel> AddressOutputModel { get; set; }

        public AddressContext(EFConfiguration config)
        {
            Config = config;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.ConnectionString);
        }
    }
}
