using profile.Application.DTOs.Article.Create;
using profile.Application.DTOs.Article.List;
using profile.Domain.Interfaces.Repositories;
using valet.lib.Auth.Domain.Interfaces.Repositories;
using valet.lib.Core.Domain.Interfaces;

namespace profile.Application.Services.Article;

public class ArticleService(
    IArticleRepository articleRepository,
    IUserRepository userRepository,
    IUnitOfWork unitOfWork)
    : IArticleService
{
    public async Task Create(ArticleCreateRequest request, Guid userId)
    {
        var user = await userRepository.GetAsync(x => x.Id == userId);
        
        if (user == null)
            throw new Exception("User not found");  
        
        var article = new Domain.Entities.Article(request.title, request.content, user.Id);

        await articleRepository.CreateAsync(article);
        await unitOfWork.CommitAsync();
    }

    public async Task<GetAllArticlesFromUserResponse> GetAllArticlesFromUser()
    {
        var articles = await articleRepository.GetAllAsync();
        
        return new GetAllArticlesFromUserResponse(articles.Select(x => new ArticleDTO(x.Title, x.Content)).ToList());
    }
}