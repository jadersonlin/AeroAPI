using Microsoft.EntityFrameworkCore;

namespace AeroAPI.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        { }
    }
}
