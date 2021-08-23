using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistence.EntityConfigurations
{
    public class ApplicationUserConfiguration : EntityTypeConfiguration<ApplicationUser>
    {
        public ApplicationUserConfiguration()
        {
            Property(a => a.Name)
                .IsRequired()
                .HasMaxLength(100);


            HasMany(a => a.Followers)
               .WithRequired(k => k.Followee)
               .WillCascadeOnDelete(false);

            HasMany(a => a.Followees)
               .WithRequired(k => k.Follower)
               .WillCascadeOnDelete(false);
        }
    }
}
