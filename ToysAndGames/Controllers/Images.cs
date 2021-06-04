using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Images : ControllerBase
    {
        [HttpGet("{image_name_ext}")]
        public async Task<ActionResult> get([FromRoute] string image_name_ext)
        {
          
            string path = "C:/Users/alfredo.gonzalez/source/repos/ToysAndGames/ToysAndGames/wwwroot/productos/"+image_name_ext;
            Byte[] bytes_from_img = await System.IO.File.ReadAllBytesAsync(path);
            return File(bytes_from_img, "image/jpeg");

        }
    }
}
