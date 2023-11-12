using N71BlogPost.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Persistence.Repositories.CommentRepository
{
    public interface ICommentRepository
    {
        IQueryable<Comment> Get(bool asNoTracking = true);
        //ValueTask<Comment> GetByCommentId(Guid CommentId
        ValueTask<Comment> GetByIdAsync(Guid id, bool asNoTracking = true);
        ValueTask<Comment> CreateAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Comment> UpdateAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default);
        ValueTask<Comment> DeleteAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default);
    }
}
