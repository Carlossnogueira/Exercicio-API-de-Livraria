using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Communication.Requests
{
    [Route("api/[controller]")]
    [ApiController]
    public class RequestBookByIdJson : ControllerBase
    {
        public int id { get; set; }
    }
}
