using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using profile.Domain.Entities;

namespace profile.Infrastructure.Data.Mappings
{
    public class ArticleMap : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("TB_ARTICLE").HasKey(x => x.Id);

            builder.Property(x => x.Id).HasColumnName("ART_ID").IsRequired();
            builder.Property(x => x.CreatedAt).HasColumnName("ART_CREATED_AT");
            builder.Property(x => x.UpdatedAt).HasColumnName("ART_UPDATED_AT");
            builder.Property(x => x.Title).HasColumnName("ART_TITLE").IsRequired().HasMaxLength(50);
            builder.Property(x => x.Content).HasColumnName("ART_CONTENT").IsRequired();
            builder.Property(x => x.AuthorId).HasColumnName("ART_AUTHOR_ID").IsRequired();

            builder.HasOne(x => x.Author)
                   .WithMany(x => x.Articles)
                   .HasForeignKey(x => x.AuthorId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
