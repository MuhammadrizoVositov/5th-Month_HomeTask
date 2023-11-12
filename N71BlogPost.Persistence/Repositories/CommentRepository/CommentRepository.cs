using Microsoft.EntityFrameworkCore;
using N71BlogPost.Domain.Entity;
using N71BlogPost.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Persistence.Repositories.CommentRepository
{
    public class CommentRepository :EntityBaseRepository<Comment,AppDbContext> ,ICommentRepository
    {
        public CommentRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public ValueTask<Comment> CreateAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default)=>
            base.CreateAsync(Comment, saveChanges, cancellationToken);
            
        

        public ValueTask<Comment> DeleteAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default)=>
            base.Delete(Comment, saveChanges, cancellationToken);
      

        public IQueryable<Comment> Get(bool asNoTracking = true)=>
            base.Get(asNoTracking);
        

        public ValueTask<Comment> GetByIdAsync(Guid id, bool asNoTracking = true)=>
            base.GetByIdAsync(id, asNoTracking);
        

        public ValueTask<Comment> UpdateAsync(Comment Comment, bool saveChanges = true, CancellationToken cancellationToken = default)=>
            base.Update(Comment, saveChanges,cancellationToken);
           
    }
}
