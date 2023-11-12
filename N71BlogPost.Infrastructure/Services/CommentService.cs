using N71BlogPost.Application.Services;
using N71BlogPost.Domain.Entity;
using N71BlogPost.Persistence.Repositories.CommentRepository;

namespace N71BlogPost.Infrastructure.Services;

public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;

    public CommentService(ICommentRepository commentRepository)
    {
        _commentRepository = commentRepository;
    }

    public async ValueTask<Comment> CreateAsync(Comment comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        return await _commentRepository.CreateAsync(comment,saveChanges,cancellationToken);
    }

    public async ValueTask<Comment> DeleteAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var delete=await _commentRepository.GetByIdAsync(Comment.Id);
        return await _commentRepository.DeleteAsync(delete,saveChanges,cancellationToken);
    }

    public  IQueryable<Comment> Get(bool asNoTracking = true)
    {
        return  _commentRepository.Get(asNoTracking).AsQueryable();
    }

    public async ValueTask<Comment> GetByIdAsync(Guid id, bool asNoTracking = true)
    {
        return await _commentRepository.GetByIdAsync(id, asNoTracking);
    }

    public async ValueTask<Comment> UpdateAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var update = await _commentRepository.GetByIdAsync(Comment.Id);
        update.Description=Comment.Description;
        return await _commentRepository.UpdateAsync(update,saveChanges,cancellationToken);
    }
}
