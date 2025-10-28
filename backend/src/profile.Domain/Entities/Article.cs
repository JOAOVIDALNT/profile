using valet.lib.Core.Domain.Entities;

namespace profile.Domain.Entities
{
    public class Article : BaseEntity
    {
        public string Title { get; private set; } = string.Empty;
        public string Content { get; private set; } = string.Empty;
        public virtual LocalUser Author { get; private set; }
        public Guid AuthorId { get; private set; }

        public Article(string title, string content, Guid authorId)
        {
            SetTitle(title);
            SetContent(content);
            SetAuthor(authorId);
        }

        private Article()
        {
        }

        private void SetTitle(string title)
        {
            if (string.IsNullOrEmpty(title))
                throw new ArgumentNullException("title");
            if (title.Length > 100)
                throw new ArgumentOutOfRangeException("title");
            
            this.Title = title;
        }

        private void SetContent(string content)
        {
            if (string.IsNullOrEmpty(content))
                throw new ArgumentNullException("content");

            if (content.Length < 100)
                throw new Exception("Content must be at least 100 characters");
            
            this.Content = content;
        }

        private void SetAuthor(Guid authorId)
        {
            if (authorId == Guid.Empty)
                throw new ArgumentNullException("authorId");
            this.AuthorId = authorId;
        }
    }
}
