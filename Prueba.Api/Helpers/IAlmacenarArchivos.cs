using System.Threading.Tasks;

namespace Prueba.Api.Helpers
{
    public interface IAlmacenarArchivos
    {
        Task<string> GuardarArchivo(byte[] contenido, string nombreArchivo);
    }
}