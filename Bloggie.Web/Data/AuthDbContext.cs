using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Bloggie.Web.Data
{
    public class AuthDbContext : IdentityDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options):base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            var superAdminRoleId = "86463b5a-5e6a-478d-a499-618964b347d5";
            var AdminRoleId = "de8632de-9c08-4310-8bd3-a53f972ad500";
            var UserRoleId = "57b33460-8831-407d-a663-8bdaf987c3aa";

            //Seed Roles (User, Admin, SuperAdmin)
            var roles = new List<IdentityRole>
            {
                new IdentityRole()
                {
                    Name ="SuperAdmin",
                    NormalizedName="SuperAdmin",
                    Id =superAdminRoleId,
                    ConcurrencyStamp=superAdminRoleId
                },
                new IdentityRole()
                {
                    Name ="Admin",
                    NormalizedName="Admin",
                    Id =AdminRoleId,
                    ConcurrencyStamp=AdminRoleId
                },
                new IdentityRole()
                {
                    Name ="User",
                    NormalizedName="User",
                    Id =UserRoleId,
                    ConcurrencyStamp=UserRoleId
                }
            };
            builder.Entity<IdentityRole>().HasData(roles);

            // Seed SuperAdmin User
            var superAdminId = "8547dfbf-6634-4351-be7b-472a2c3bb561";
            var superAdminUser = new IdentityUser()
            {
                Id = superAdminId,
                UserName = "superadmin@bloggie.com",
                Email = "superadmin@bloggie.com",
                NormalizedEmail = "superadmin@bloggie.com".ToUpper(),
                NormalizedUserName = "superadmin@bloggie.com".ToUpper()
            };
            superAdminUser.PasswordHash = new PasswordHasher<IdentityUser>()
                .HashPassword(superAdminUser, "superadmin123");

            builder.Entity<IdentityUser>().HasData(superAdminUser);

            // Add all Roles the SuperAdmin user can be associated with
            var superAdminRoles = new List<IdentityUserRole<string>>()
            {
                new IdentityUserRole<string>
                {
                    RoleId =superAdminRoleId,
                    UserId =superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId =AdminRoleId,
                    UserId =superAdminId
                },
                new IdentityUserRole<string>
                {
                    RoleId =UserRoleId,
                    UserId =superAdminId
                }
            };
            //this associate the user with the roles
            builder.Entity<IdentityUserRole<string>>().HasData(superAdminRoles);

        }
    }
}
