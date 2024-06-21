using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
using SerilogExample.Model;

namespace SerilogExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        private readonly ILogger<BlogController> _logger;

        public BlogController(ILogger<BlogController> logger)
        {
            _logger = logger;
        }

        #region Get blogs

        [HttpGet]
        public IActionResult GetBlogs() 
        {
            List<BlogDataModel> lst =
                new()
                {
                    new BlogDataModel
                    {
                        BlogId = Guid.NewGuid(),
                        BlogTitle = "Success",
                        BlogAuthor = "Thet Htar",
                        BlogContent = "What is success"
                    },
                    new BlogDataModel
                    {
                        BlogId = Guid.NewGuid(),
                        BlogTitle = "Moral",
                        BlogAuthor = "Linn Thit",
                        BlogContent = "What is Moral"
                    },

                    new BlogDataModel
                    {
                        BlogId = Guid.NewGuid(),
                        BlogTitle = "Ethic",
                        BlogAuthor = "Moe Thet",
                        BlogContent = "What is Ethic"
                    }
                };

            _logger.LogInformation("Blog list => " + JsonConvert.SerializeObject(lst));
            return Ok(lst);
        }

        #endregion

        #region Test logging

        [HttpGet("testing")]
        public IActionResult TestLogging()
        {
            Log.Debug("test logging");
            return Ok();
        }

        #endregion
    }
}
