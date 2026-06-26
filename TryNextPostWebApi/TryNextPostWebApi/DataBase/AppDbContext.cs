using Microsoft.EntityFrameworkCore;
using TryNextPostWebApi.Entities;

namespace TryNextPostWebApi.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<MailSettings> MailSettings { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
    }
}
