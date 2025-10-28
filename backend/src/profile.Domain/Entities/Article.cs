using valet.lib.Core.Domain.Entities;

namespace profile.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public virtual LocalUser? Author { get; set; }
        public Guid AuthorId { get; set; }
    }
}
