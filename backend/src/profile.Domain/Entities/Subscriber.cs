using valet.lib.Core.Domain.Entities;

namespace profile.Domain.Entities
{
    public class Subscriber : BaseEntity
    {
        public string Email { get; set; } = string.Empty;
        public virtual ICollection<LocalUser> Subscriptions { get; set; } = [];
    }
}
