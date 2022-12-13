using Domain;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Repository
{
    public class UserWalletContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}