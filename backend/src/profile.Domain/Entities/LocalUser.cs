using valet.lib.Auth.Domain.Entities;

namespace profile.Domain.Entities
{
    public class LocalUser(string firstName, string lastName, string email, string password)
        : User(firstName, lastName, email, password)
    {
        public virtual ICollection<Subscriber> Subscribers { get; set; } = [];
        public virtual ICollection<Article> Articles { get; set; } = [];
    }
}
