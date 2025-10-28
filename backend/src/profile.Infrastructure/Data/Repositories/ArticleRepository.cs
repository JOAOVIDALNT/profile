using profile.Domain.Entities;
using profile.Domain.Interfaces.Repositories;
using valet.lib.Core.Data.Repositories;

namespace profile.Infrastructure.Data.Repositories;

public class ArticleRepository(AppDbContext db) : Repository<Article>(db), IArticleRepository
{
}