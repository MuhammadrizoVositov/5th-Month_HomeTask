using Microsoft.EntityFrameworkCore;
using N71BlogPost.Domain.Entity;
using N71BlogPost.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N71BlogPost.Persistence.Repositories.BlogRepository
{
    public class BlogPostRepository : EntityBaseRepository<Blog, AppDbContext>, IBlogRepository
    {
        public BlogPostRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public ValueTask<Blog> DeleteAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default)=>
            base.Delete(Blog, saveChanges, cancellationToken);
     

        public ValueTask<Blog> GetByIdAsync(Guid id, bool asNoTracking = true)=>
            base.GetByIdAsync(id, asNoTracking);


        public ValueTask<Blog> UpdateAsync(Blog Blog, bool saveChanges = true, CancellationToken cancellationToken = default) =>
            base.Update(Blog, saveChanges, cancellationToken);
        

        public ValueTask<Blog> CreateAsync(Blog Blog, bool saveChanges, CancellationToken cancellationToken)=>
            base.CreateAsync(Blog, saveChanges, cancellationToken);
        

        public IQueryable<Blog> Get(bool asNoTracking)=>
            base.Get(asNoTracking);
        
    }
}
