using FootyConnect.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FootyConnect.Persistence.DbConfigurations
{
    public class MatchRequestConfiguration : IEntityTypeConfiguration<MatchRequest>
    {
        public void Configure(EntityTypeBuilder<MatchRequest> builder)
        {
            builder.HasOne(mr => mr.TimeSlot)
                .WithMany(t => t.MatchRequests)
                .HasForeignKey(mr => mr.TimeSlotId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mr => mr.RequestingTeam)
                .WithMany(t => t.MatchRequests)
                .HasForeignKey(mr => mr.RequestingTeamId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(mr => mr.FootballPitch)
                .WithMany(t => t.MatchRequests)
                .HasForeignKey(mr => mr.FootballPitchId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
