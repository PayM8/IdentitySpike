
namespace Spike.Web.Areas.V01.Controllers
{
    using System.Collections.Generic;
    using System.Web.Http;
    using Contracts.Books;
    using Public.Services;

    [RoutePrefix("V01/api/Book")]
    public class BookController : ApiController
    {
        [HttpGet]
        [Route("")]
        public IEnumerable<Book> Get()
        {
            var service = ServiceFactory.CreateBookService();
            return service.GetAllBooks();
        }

        [HttpGet]
        [Route("{id:int}")]
        public Book Get(int id)
        {
            var service = ServiceFactory.CreateBookService();
            return service.GetBook(id);
        }

        [HttpPost]
        [Route("")]
        public Book Post([FromBody]Book book)
        {
            var service = ServiceFactory.CreateBookService();
            return service.AddBook(book);
        }
    }
}
