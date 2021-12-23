using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Prueba.Api.Helpers;
using Prueba.Api.Repositorio;
using Prueba.Models;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prueba.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GatosController : ControllerBase
    {
        private readonly IAlmacenarArchivos almacenar;
        private readonly Mapeo _db;
        public GatosController(Mapeo db, IAlmacenarArchivos almacenar)
        {
            this.almacenar = almacenar;
            _db = db;

        }

        [HttpGet("listado")]

        public IActionResult GetGatos()
        {
            var query = _db.TablaGatos.ToList();
            return Ok(query);
        }

        [HttpPost("guardar")]
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
                    string nombreurl = $"{gato.id}.{Path.GetExtension(gato.url)}";
                    string url = await almacenar.GuardarArchivo(imageBytes, nombreurl);
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

    }
}
