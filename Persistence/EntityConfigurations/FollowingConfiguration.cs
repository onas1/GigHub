using GigHub.Core.Models;
using System.Data.Entity.ModelConfiguration;

namespace GigHub.Persistence.EntityConfigurations
{
    public class FollowingConfiguration : EntityTypeConfiguration<Following>
    {
        public FollowingConfiguration()
        {
            Property(a => a.FollowerId).HasColumnOrder(1);
            Property(a => a.FolloweeId).HasColumnOrder(2);
        }
    }
}
