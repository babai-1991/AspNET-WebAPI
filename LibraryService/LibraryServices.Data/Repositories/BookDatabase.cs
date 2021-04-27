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

        public List<Book> GetBookByAuthor(string authorName)
        {
            List<Book> books = _libraryContext.Books.Where(b => b.Author.Contains(authorName)).ToList();
            return books;
        }

        public string GetAuthorByBookId(int bookid)
        {
            return _libraryContext.Books.FirstOrDefault(b => b.Id == bookid)?.Author;
        }

        public Book GetBookByAuthorAndYear(string author, int year)
        {
            Book book = _libraryContext.Books.FirstOrDefault(b =>b.Author.Contains(author) && b.PublicationYear==year);
            return book;
        }

        public Book AddCost(int bookid, Cost cost)
        {
            Book book = GetBook(bookid);
            book.Cost = cost;
            _libraryContext.SaveChanges();
            return book;
        }
    }
}
