using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/Elotes")]
    public class ElotesController : ControllerBase
    {
        [HttpGet]
        public List<string> getElotes()
        {
            return new List<string>
            {
                "Crudo",
                "DoriElote",
                "Chirindongo",
                "Esquites"
            };
        }
        
    }
}