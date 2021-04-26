using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;

namespace LibraryService.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
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
        public IHttpActionResult Delete(int id)
        {
            bool result = _bookRepository.RemoveBook(id);
            if (result)
            {
                return Ok(_bookRepository.GetAllBooks());
            }

            return NotFound();
        }
        [HttpPut]
        public IHttpActionResult Update(Book book)
        {
            IEnumerable<Book> books = _bookRepository.UpdateBook(book.Id, book);
            if (books != null)
            {
                return Ok(books);
            }
            return NotFound();
        }
    }
}