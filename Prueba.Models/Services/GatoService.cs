using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Models.Services
{
    public class GatoService
    {
        public async Task<Gato> GetGato()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://api.thecatapi.com/v1/images/search"))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Gato> gatos = JsonConvert.DeserializeObject<List<Gato>>(json);
                    return gatos.ElementAt(0);
                }
            }
        }

        public async Task<string> GuardarGato(string json)
        {
            string mensaje = string.Empty;
            using (var client = new HttpClient())
            {
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                using (var response = await client.PostAsync("https://localhost:44339/api/Gatos/guardar", content))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        mensaje = "gato guardado.";
                    }
                    else
                    {
                        mensaje = "no se ha podido guardar el gato.";
                    }
                }
            }
            return mensaje;
        }

        public async Task<List<Gato>> GetGatos()
        {
            using (var client = new HttpClient())
            {
                using (var response = await client.GetAsync("https://localhost:44339/api/Gatos/listado"))
                {
                    string json = await response.Content.ReadAsStringAsync();
                    List<Gato> gatos = JsonConvert.DeserializeObject<List<Gato>>(json);
                    return gatos;
                }
            }
        }

        public async Task<string> Eliminar(string id)
        {
            string mensaje = string.Empty;
            using (var client = new HttpClient())
            {
                using (var response = await client.DeleteAsync($"https://localhost:44339/api/Gatos/delete/{id}"))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        mensaje = "gato eliminado.";
                    }
                    else
                    {
                        mensaje = "no se ha podido eliminar el gato.";
                    }
                }
            }
            return mensaje;
        }
    }
}
