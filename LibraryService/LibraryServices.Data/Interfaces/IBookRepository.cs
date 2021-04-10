using System.Collections.Generic;
using LibraryServices.Data.Models;

namespace LibraryServices.Data.Interfaces
{
    public interface IBookRepository
    {
        Book GetBook(int id);
        IEnumerable<Book> GetAllBooks();

    }
}
