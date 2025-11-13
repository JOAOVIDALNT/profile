using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using profile.Domain.Entities;

namespace profile.Infrastructure.Data.Mappings;

public class SubscriberMap : IEntityTypeConfiguration<Subscriber>
{
    public void Configure(EntityTypeBuilder<Subscriber> builder)
    {
        builder.ToTable("TB_SUBSCRIBER").HasKey(x => x.Id);
        
        builder.Property(x => x.Id).HasColumnName("SUB_ID").IsRequired();
        builder.Property(x => x.CreatedAt).HasColumnName("SUB_CREATED_AT");
        builder.Property(x => x.UpdatedAt).HasColumnName("SUB_UPDATED_AT");
        builder.Property(x => x.Email).HasColumnName("SUB_EMAIL").HasMaxLength(100);

        builder.HasMany(s => s.Subscriptions)
            .WithMany(u => u.Subscribers)
            .UsingEntity(x => x.ToTable("TB_SUBSCRIPTIONS"));
    }
}