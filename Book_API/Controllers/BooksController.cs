using BusinessTier;
using DataAccess.RequestModels;
using DataAccess.ResponseModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Book_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        // GET: api/<BooksController>
        [HttpGet]
        public ActionResult<List<BookResponseModel>> Get()
        {
            var list = _bookService.GetAllBooks();
            return Ok(list);
        }

        // GET api/<BooksController>/5
        [HttpGet("{id}")]
        public ActionResult<BookResponseModel> Get(int id)
        {
            var book = _bookService.GetBook(id);
            return Ok(book);
        }

        // POST api/<BooksController>
        [HttpPost]
        public ActionResult<BookResponseModel> Post([FromBody] BookRequestModel bookRequestModel)
        {
            return Ok(_bookService.CreateBook(bookRequestModel));
        }

        // PUT api/<BooksController>/5
        [HttpPut("{id}")]
        public ActionResult<BookResponseModel> Put(int id, [FromBody] BookRequestModel bookRequestModel)
        {
            return Ok(_bookService.UpdateBook(id, bookRequestModel));
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{id}")]
        public ActionResult<BookResponseModel> Delete(int id)
        {
            return Ok(_bookService.DeleteBook(id));
        }
    }
}
