using profile.Application.DTOs.Article.Create;
using profile.Application.DTOs.Article.List;
using profile.Domain.Interfaces.Repositories;
using valet.lib.Auth.Domain.Interfaces.Repositories;
using valet.lib.Core.Domain.Interfaces;

namespace profile.Application.Services.Article;

public class ArticleService : IArticleService
{
    private readonly IArticleRepository _articleRepository;
    private readonly IUserRepository _userRepository;
    private readonly IUnitOfWork _unitOfWork;

    public ArticleService(IArticleRepository articleRepository, IUserRepository userRepository, IUnitOfWork unitOfWork)
    {
        _articleRepository = articleRepository;
        _userRepository = userRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task Create(ArticleCreateRequest request, Guid userId)
    {
        var user = await _userRepository.GetAsync(x => x.Id == userId);
        
        if (user == null)
            throw new Exception("User not found");  
        
        var article = new Domain.Entities.Article(request.title, request.content, user.Id);

        await _articleRepository.CreateAsync(article);
        await _unitOfWork.CommitAsync();
    }

    public async Task<GetAllArticlesFromUserResponse> GetAllArticlesFromUser()
    {
        var articles = await _articleRepository.GetAllAsync();
        
        return new GetAllArticlesFromUserResponse(articles.Select(x => new ArticleDTO(x.Title, x.Content)).ToList());
    }
}