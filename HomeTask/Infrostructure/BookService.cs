using HomeTask.Application;
using HomeTask.Domain.Models;
using HomeTask.Persistance.Repositories;

namespace HomeTask.Infrostructure;

public class BookService : IBookService
{
    private readonly IBookRepository bookRepository;

    public BookService(IBookRepository bookRepository)
    {
        this.bookRepository = bookRepository;
    }

    ValueTask<Book> IBookService.CreateAsync(Book book, bool saveChanges, CancellationToken cancellationToken)
    {
        return bookRepository.CreateAsync(book, saveChanges, cancellationToken);
    }

    ValueTask<Book> IBookService.DeleteAsync(Book book, bool saveChanges, CancellationToken cancellationToken)
    {
        return bookRepository.DeleteAsync(book, saveChanges, cancellationToken);
    }

    IQueryable<Book> IBookService.Get(Func<Book, bool> predicate, bool asNoTracking)
    {
        return bookRepository.Get(predicate, asNoTracking);
    }

    ValueTask<Book?> IBookService.GetById(Guid id, bool asNoTracking, CancellationToken cancellationToken)
    {
        return bookRepository.GetById(id, asNoTracking, cancellationToken);
    }

    ValueTask<Book> IBookService.UpdateAsync(Book book, bool saveChanges, CancellationToken cancellationToken)
    {
        return bookRepository.UpdateAsync(book, saveChanges, cancellationToken);
    }
}
