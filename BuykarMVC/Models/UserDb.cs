using Microsoft.EntityFrameworkCore;

namespace BuykarMVC.Models
{
    public class UserDb : DbContext
    {
        public UserDb(DbContextOptions<UserDb>pot) : base(pot)
        {            
        }
        public DbSet<User> UserTable { get; set; }
    }
}
