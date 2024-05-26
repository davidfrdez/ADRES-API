using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ADRES_API.Models
{
    public class ApplicationDbContextFactory
    {
        private readonly IConfiguration _configuration;

        public ApplicationDbContextFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ApplicationDbContext CreateDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("DefaultConnection"));

            return new ApplicationDbContext(optionsBuilder.Options, _configuration);
        }
    }
}
