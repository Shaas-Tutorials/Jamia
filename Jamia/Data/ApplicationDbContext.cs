using Jamia.Infrastructure;
using Jamia.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Jamia.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema(SchemaNames.Identity);
            builder.Entity<ApplicationUser>(entity => { entity.ToTable(name: "Users"); });
            builder.Entity<IdentityRole>(entity => { entity.ToTable(name: "Roles"); });
            builder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("UserRoles"); });
            builder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("UserClaims"); });
            builder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("UserLogins"); });
            builder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("UserTokens"); });
            builder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("RoleClaims"); });

            //Building Many to Many relationship between ApplicationUser and Institute
            builder.Entity<UserInstitute>().HasKey(t => new { t.ApplicationUserId, t.InstituteId });
            builder.Entity<UserInstitute>().HasOne(x => x.ApplicationUser).WithMany(x => x.UserInstitutes).HasForeignKey(x => x.ApplicationUserId);
            builder.Entity<UserInstitute>().HasOne(x => x.Institute).WithMany(x => x.UserInstitutes).HasForeignKey(x => x.InstituteId);
        }
        public DbSet<Jamia.Models.Session> Session { get; set; }
        public DbSet<Jamia.Models.Course> Course { get; set; }
        public DbSet<Jamia.Models.Institute> Institute { get; set; }
        public DbSet<Jamia.Models.Campus> Campus { get; set; }
        public DbSet<Jamia.Models.UserInstitute> UserInstitute { get; set; }
    }
}
