using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Gatos.Models;
using Prueba.Gatos.Repositorio;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prueba.Gatos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatosController : ControllerBase
    {
        private readonly IWebHostEnvironment env;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly Mapeo _db;
        public GatosController(Mapeo db, IWebHostEnvironment env,
            IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            this.env = env;
            this.httpContextAccessor = httpContextAccessor;
        }

        [HttpGet("listado")]

        public IActionResult GetGatos()
        {
            var query = _db.TablaGatos.ToList();
            return Ok(query);
        }


        [HttpGet("guardar")]

        public async Task<IActionResult> Guardar(Gato gato)
        {
            try
            {
                byte[] imageBytes;
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(gato.url))
                    {
                        imageBytes = await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
                    }

                }
                if (imageBytes.Length > 0)
                {
                    string url = await GuardarArchivo(imageBytes, gato.url);
                    gato.url = url;
                }
                _db.TablaGatos.Add(gato);
                _db.SaveChanges();
                return Created(string.Empty, gato);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }

        }


        [HttpDelete("delete/{id}")]
        public IActionResult Eliminar(string id)
        {
            try
            {
                var query = _db.TablaGatos.Find(id);
                if (query == null)
                {
                    return NotFound("no se encuentra el gato.");
                }
                _db.TablaGatos.Remove(query);
                _db.SaveChanges();
                return NoContent();
            }

            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error: {ex.Message}");
            }
        }
        public async Task<string> GuardarArchivo(byte[] contenido, string nombreArchivo)
        {
            string folder = Path.Combine(env.WebRootPath, "imagenes");

            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            string ruta = Path.Combine(folder, nombreArchivo);
            await System.IO.File.WriteAllBytesAsync(ruta, contenido);

            var urlActual = $"{httpContextAccessor.HttpContext.Request.Scheme}://{httpContextAccessor.HttpContext.Request.Host}";
            var urlParaBD = Path.Combine(urlActual, "imagenes", nombreArchivo).Replace("\\", "/");
            return urlParaBD;
        }
    }
}
