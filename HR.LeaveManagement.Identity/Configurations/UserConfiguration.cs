using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            builder.HasData(
                new ApplicationUser
                {
                    Id = "95af8717-e912-4db9-b7f2-59a8bb3b0648",
                    Email = "admin@unknown.com",
                    FirstName = "System",
                    LastName = "Admin",
                    UserName = "admin@unknown.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = "41ca8caa-b68f-471d-bdbd-88b85688668c",
                    Email = "user@unknown.com",
                    FirstName = "System",
                    LastName = "User",
                    UserName = "user@unknown.com",
                    PasswordHash = hasher.HashPassword(null, "P@ssw0rd1"),
                    EmailConfirmed = true
                }
            );
        }
    }
}