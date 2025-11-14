using System.Net.Mail;
using valet.lib.Core.Domain.Entities;

namespace profile.Domain.Entities
{
    public class Subscriber : BaseEntity
    {
        public string Email { get; private set; } = string.Empty;
        public virtual ICollection<Subscription> Subscriptions { get; set; } = [];

        public Subscriber(string email)
        {
            SetEmail(email);
        }

        protected Subscriber()
        {
        }

        private void SetEmail(string email)
        {
            if (!IsEmailValid(email))
                throw new ArgumentException("Invalid email");
            this.Email = email;
        }
        
        private bool IsEmailValid(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return false;

            try
            {
                var addr = new MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
