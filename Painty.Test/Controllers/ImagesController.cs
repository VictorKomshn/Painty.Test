using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Painty.Test.Controllers
{

    [Route("images")]
    [ApiController]
    public class ImagesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task AddAsync(IFormFile image,Guid userId)
        {
            var fileExtension = System.IO.Path.GetExtension(image.FileName);
        }

        [HttpGet]
        public async Task<File> GetAsync()
        {

        }

        [HttpGet]
        [Route("friend/{friendId}")]
        public async Task<File> GetAsync([FromQuery] string friendId)
        {

        }
    }
}
