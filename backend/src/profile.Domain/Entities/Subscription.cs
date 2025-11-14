using valet.lib.Core.Domain.Entities;

namespace profile.Domain.Entities;

public class Subscription : BaseEntity
{
    protected Subscription() { }
    
    public Subscription(LocalUser author, Subscriber subscriber)
    {
        this.Author = author ?? throw new ArgumentNullException(nameof(author));
        this.Subscriber = subscriber ??  throw new ArgumentNullException(nameof(subscriber));
        AuthorId =  author.Id;
        SubscriberId = subscriber.Id;
    }
    public virtual LocalUser Author { get; private set; }
    public virtual Subscriber Subscriber { get; private set; } // IN THE FUTURE, WITH AUTHENTICATION SET THIS WILL BE ANOTHER USER
    public Guid AuthorId { get; private set; }
    public Guid SubscriberId{ get; private set; }
}