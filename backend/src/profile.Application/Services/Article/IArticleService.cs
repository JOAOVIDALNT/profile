using profile.Application.DTOs.Article.Create;
using profile.Application.DTOs.Article.List;

namespace profile.Application.Services.Article;

public interface IArticleService
{
    Task Create(ArticleCreateRequest request, Guid userId);
    Task<GetAllArticlesFromUserResponse> GetAllArticlesFromUser();
}