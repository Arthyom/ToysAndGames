using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.Utilities
{
    public class ImageLoader
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor accs;

        public ImageLoader(
            IWebHostEnvironment env,
            IHttpContextAccessor accs 
        )
        {
            this.env = env;
            this.accs = accs;
        }



        public async Task<string> guardar( string contenedor, IFormFile form_file_data )
        {
            string file_ext = Path.GetExtension(form_file_data.FileName);
            string file_name = $"{Guid.NewGuid()}{file_ext}";
            string folder = Path.Combine(env.WebRootPath, contenedor);
            string folder_and_filename = Path.Combine(folder, file_name);

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            using (var memory_stream = new MemoryStream())
            {
                await form_file_data.CopyToAsync(memory_stream);
                await File.WriteAllBytesAsync(folder_and_filename, memory_stream.ToArray());
            }

            string url_actual = $"{accs.HttpContext.Request.Scheme}://{accs.HttpContext.Request.Host}";
            string ruta_db = Path.Combine(url_actual, folder_and_filename).Replace("\\", "/");
            return file_name;
        }
    }
}
