using HomeTask.Domain.Models;
using HomeTask.Persistance.DataAccess;

namespace HomeTask.Persistance.Repositories;

public class BookRepository :  EntityBaseRepository<Book,AppDbContext>,IBookRepository
{
    private readonly AppDbContext dbContext;

    public BookRepository(AppDbContext dbContext) : base(dbContext)
    {
        this.dbContext = dbContext;
    }

    ValueTask<Book> IBookRepository.CreateAsync(Book book, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.CreateAsync(book, saveChanges, cancellationToken);
    }

    ValueTask<Book> IBookRepository.DeleteAsync(Book book, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.DeleteAsync(book, saveChanges, cancellationToken);
    }

    IQueryable<Book> IBookRepository.Get(Func<Book, bool> predicate, bool asNoTracking)
    {
        return base.Get(predicate, asNoTracking);
    }

    ValueTask<Book?> IBookRepository.GetById(Guid id, bool asNoTracking, CancellationToken cancellationToken)
    {
        return base.GetByIdAsync(id, asNoTracking, cancellationToken);
    }

    ValueTask<Book> IBookRepository.UpdateAsync(Book book, bool saveChanges, CancellationToken cancellationToken)
    {
        return base.UpdateAsync(book, saveChanges, cancellationToken);
    }
}
