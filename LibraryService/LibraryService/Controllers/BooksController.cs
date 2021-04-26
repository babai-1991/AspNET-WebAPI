using System.Collections.Generic;
using System.Web.Http;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;

namespace LibraryService.Controllers
{
    public class BooksController : ApiController
    {
        private readonly IBookRepository _bookRepository;

        public BooksController(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _bookRepository.GetAllBooks();
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            Book book = _bookRepository.GetBook(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public IHttpActionResult PostBook(Book book)
        {
            bool result = _bookRepository.AddBook(book);
            if (result)
            {
                return Ok(book);
            }

            return BadRequest();
        }

        [HttpDelete]
        public IHttpActionResult DeleteBook(int id)
        {
            bool result = _bookRepository.RemoveBook(id);
            if (result)
            {
                return Ok(_bookRepository.GetAllBooks());
            }

            return NotFound();
        }
        [HttpPut]
        public IHttpActionResult UpdateBook(int id, Book book)
        {
            IEnumerable<Book> books = _bookRepository.UpdateBook(id, book);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
    }
}