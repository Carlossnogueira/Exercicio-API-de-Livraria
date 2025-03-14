using Livraria.Communication.Configuration;
using Livraria.Communication.Requests;
using Livraria.Model;
using Livraria.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BookController : ControllerBase
    {
        // Create book
        [HttpPost]
        [ProducesResponseType(typeof(RequestRegisterBookJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult CreateBook([FromBody] RequestRegisterBookJson request)
        {
            if(request == null || string.IsNullOrEmpty(request.Author) || string.IsNullOrEmpty(request.Tittle))
            {
                return BadRequest("Some of rows are empty!");
            }

            var newbook = new Book(request.Tittle,request.Author,request.Gender,request.Price,request.Amount);
            BookRepository.AddBook(newbook);
            return Created(string.Empty, newbook);
        }

        // Return all books
        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllBooks()
        {
            
            if(BookRepository.books.Count == 0){
                return NoContent();
            }

            return Ok(BookRepository.GetBooks());
        }

        // TODO Update a book


        // TODO Delete a book


        //TODO Get book by ID
        [HttpGet("/{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status204NoContent)]
        public IActionResult GetById([FromRoute] RequestBookByIdJson request){
            if(request == null){
                return NoContent();
            }
            
            var bookResponse = BookRepository.books[request.id];
            return Ok(bookResponse);
        }
    }
}
