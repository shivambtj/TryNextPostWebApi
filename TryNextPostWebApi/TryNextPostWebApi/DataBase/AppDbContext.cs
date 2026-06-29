using Microsoft.EntityFrameworkCore;
using TryNextPostWebApi.Entities;
using TryNextPostWebApi.Entities.Order;

namespace TryNextPostWebApi.DataBase
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<UserMaster> UserMasters { get; set; }
        public DbSet<MailSettings> MailSettings { get; set; }
        public DbSet<RoleMaster> RoleMasters { get; set; }
        public DbSet<MenueItemMaster> MenueItemMaster { get; set; }
        public DbSet<UserPermissionMaster> userPermissions { get; set; }
        public DbSet<OrderTypeMaster> OrderTypeMasters { get; set; }
    }
}
