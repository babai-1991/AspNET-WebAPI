using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using LibraryServices.Data.Interfaces;
using LibraryServices.Data.Models;

namespace LibraryService.Controllers
{
    [EnableCors(origins: "https://localhost:44346", headers:"*",methods:"*")]
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

        [HttpGet]
        [Route("api/books/author/{id}")]
        [Route("api/books/{id}/author")]
        public IHttpActionResult GetAuthorByBookId(int id)
        {
            string authorName = _bookRepository.GetAuthorByBookId(id);
            if (authorName==null)
            {
                return NotFound();
            }

            return Ok(authorName);
        }
        [HttpGet]
        [Route("api/books/authorname/{authorname}")]
        public IHttpActionResult GetBookByAuthor(string authorname)
        {
            List<Book> books = _bookRepository.GetBookByAuthor(authorname);
            if (books == null)
            {
                return NotFound();
            }

            return Ok(books);
        }
        [HttpGet]
        [Route("api/books/{authorName}/{year}")]
        public IHttpActionResult GetBookByAuthorAndYear(string authorName, int year)
        {
            Book book = _bookRepository.GetBookByAuthorAndYear(authorName,year);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }
    }
}