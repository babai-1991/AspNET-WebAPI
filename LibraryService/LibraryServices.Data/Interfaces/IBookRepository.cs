using System.Collections.Generic;
using LibraryServices.Data.Models;

namespace LibraryServices.Data.Interfaces
{
    public interface IBookRepository
    {
        Book GetBook(int id);
        IEnumerable<Book> GetAllBooks();
        bool AddBook(Book book);
        bool RemoveBook(int id);
        IEnumerable<Book> UpdateBook(int id, Book book);

        List<Book> GetBookByAuthor(string authorName);
        string GetAuthorByBookId(int bookid);
        Book GetBookByAuthorAndYear(string author, int year);

        Book AddCost(int bookid,Cost cost);
    }
}
