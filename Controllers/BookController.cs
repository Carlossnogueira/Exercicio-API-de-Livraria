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
            if (request == null || string.IsNullOrEmpty(request.Author) || string.IsNullOrEmpty(request.Tittle))
            {
                return BadRequest("Some of rows are empty!");
            }

            var newbook = new Book(request.Tittle, request.Author, request.Gender, request.Price, request.Amount);
            BookRepository.AddBook(newbook);
            return Created(string.Empty, newbook);
        }

        // Return all books
        [HttpGet]
        [ProducesResponseType(typeof(List<Book>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAllBooks()
        {

            if (BookRepository.books.Count == 0)
            {
                return NoContent();
            }

            return Ok(BookRepository.GetBooks());
        }

        // Update a book
        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
        public IActionResult UpdateBook([FromBody] RequestRegisterBookJson request, int id)
        {
            if(request == null )
            {
                return BadRequest(BookRepository.UpdateBook(id,request));
            }

            BookRepository.UpdateBook(id,request);
            return Ok(BookRepository.books[id]);
        }


        // Delete a book
        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteBook(int id)
        {

            var deleteBook = BookRepository.RemoveBook(id);

            if(deleteBook == false)
            {
                return NotFound();
            }

            return Ok("Book has been deleted");
        }

        // Get book by ID
        [HttpGet("get/{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetById([FromRoute] int id)
        {

            var response = BookRepository.ReturnBook(id);
            if (response == null)
            {
                return NoContent();
            }
            return Ok(response);
        }
    }
}
