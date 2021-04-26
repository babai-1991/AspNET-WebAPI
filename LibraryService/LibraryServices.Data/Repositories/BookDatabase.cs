using System.Collections.Generic;
using System.Linq;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;

namespace LibraryServices.Data.Repositories
{
    public class BookDatabase : IBookRepository
    {
        readonly LibraryContext _libraryContext = new LibraryContext();
        public Book GetBook(int id)
        {
            return _libraryContext.Books.FirstOrDefault(b => b.Id == id);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _libraryContext.Books.ToList();
        }

        public bool AddBook(Book book)
        {
            _libraryContext.Books.Add(book);
            _libraryContext.SaveChanges();
            return true;
        }

        public bool RemoveBook(int id)
        {
            Book book = _libraryContext.Books.FirstOrDefault(b => b.Id == id);
            if (book != null)
            {
                _libraryContext.Books.Remove(book);
                _libraryContext.SaveChanges();
                return true;
            }

            return false;
        }

        public IEnumerable<Book> UpdateBook(int id, Book book)
        {
            if (RemoveBook(id))
            {
                AddBook(book);
            }
            return GetAllBooks();
        }
    }
}
