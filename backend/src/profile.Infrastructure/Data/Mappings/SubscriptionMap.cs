using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using profile.Domain.Entities;

namespace profile.Infrastructure.Data.Mappings;

public class SubscriptionMap : IEntityTypeConfiguration<Subscription>
{
    public void Configure(EntityTypeBuilder<Subscription> builder)
    {
        builder.ToTable("TB_SUBSCRIPTIONS").HasKey(x => new { x.AuthorId, x.SubscriberId });
        builder.Ignore(x => x.Id);
        
        builder.Property(x => x.CreatedAt).HasColumnName("SUBS_CREATED_AT");
        builder.Property(x => x.UpdatedAt).HasColumnName("SUBS_UPDATED_AT");
        builder.Property(x => x.AuthorId).HasColumnName("SUBS_AUTHOR_ID");
        builder.Property(x => x.SubscriberId).HasColumnName("SUBS_SUBSCRIBER_ID");
        
        builder.HasOne(subs => subs.Author)
            .WithMany(a => a.Subscribers)
            .HasForeignKey(subs => subs.AuthorId);
        
        builder.HasOne(subs => subs.Subscriber)
            .WithMany(s => s.Subscriptions)
            .HasForeignKey(subs => subs.SubscriberId);

    }
}