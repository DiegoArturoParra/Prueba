using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace Prueba.Api.Helpers
{
    public class AlmacenarArchivos : IAlmacenarArchivos
    {
        private IHttpContextAccessor httpContextAccessor;
        private IWebHostEnvironment env;
        public AlmacenarArchivos(IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor)
        {
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }
        public async Task<string> GuardarArchivo(byte[] contenido, string nombreArchivo)
        {
            string folder = Path.Combine(env.WebRootPath, "imagenes");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string ruta = Path.Combine(folder, nombreArchivo);
            await File.WriteAllBytesAsync(ruta, contenido);

            var urlActual = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            var urlParaBD = Path.Combine(urlActual, "imagenes", nombreArchivo).Replace("\\", "/");
            return urlParaBD;
        }
    }
}
