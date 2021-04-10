using System.Collections.Generic;
using System.Linq;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;

namespace LibraryServices.Data.Repositories
{
    public class BookRepository:IBookRepository
    {
        public IEnumerable<Book> Books = new List<Book>()
        {
            new Book
            {
                Id = 1, Title = "The Girl on the Train", Author = "Hawkins, Paula", PublicationYear = 2015,
                CallNumber = "F HAMKI"
            },

            new Book
            {
                Id = 2, Title = "Rogue Lawyer", Author = "Grisham, John", PublicationYear = 2015, CallNumber = "F GRISH"
            },

            new Book
            {
                Id = 3, Title = "After You", Author = "Moyes, Jojo", PublicationYear = 2015, CallNumber = "F MOYES"
            },

            new Book
            {
                Id = 4, Title = "All the Light We Cannot See", Author = "Doerr, Anthony", PublicationYear = 2014,
                CallNumber = "F DOERR"
            },
            new Book
            {
                Id = 5, Title = "The Girls", Author = "Cline, Ewna", PublicationYear = 2016, CallNumber = "F CLINE"
            },

            new Book
            {
                Id = 6, Title = "The Martian", Author = "weir, Andy", PublicationYear = 2011, CallNumber = "SF WEIR"
            },

            new Book
            {
                Id = 7, Title = "Me Before You", Author = "Moyes, Jojo", PublicationYear = 2012, CallNumber = "F MOYES"
            },

            new Book
            {
                Id = 8, Title = "Alexander Hamilton", Author = "Chernow, Ron", PublicationYear = 2004,
                CallNumber = "B HAMILTO A"
            },

            new Book
            {
                Id = 9, Title = "Before the Fall", Author = "Hawley, Noah", PublicationYear = 2016,
                CallNumber = "F HAWLE"
            }
        };
        public Book GetBook(int id)
        {
            var book = Books.FirstOrDefault(b => b.Id == id);
            return book;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return Books;
        }
    }
}
