using System.Collections.Generic;
using System.Web.Http;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;
using LibraryServices.Data.Repositories;

namespace LibraryService.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        // As From UI I have to inject Concrete class here BookRepository, but UI is not ready so I am doing it inside constructor,
        //later I will uncomment the upper constructor.

        //public BooksController()
        //{
        //    _bookRepository = new BookRepository();
        //}

        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAllBooks();
        }

        public IHttpActionResult Get(int id)
        {
            Book book = _bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok();
        }
    }
}