using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Identity.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasData(
                new IdentityUserRole<string>
                {
                    RoleId = "95b75644-40a6-4802-899d-10ec4111353b",
                    UserId = "95af8717-e912-4db9-b7f2-59a8bb3b0648"
                },
                new IdentityUserRole<string>
                {
                    RoleId = "eff52106-7b29-43d4-b2c6-57ef8905908e",
                    UserId = "41ca8caa-b68f-471d-bdbd-88b85688668c"
                }
            );
        }
    }
}