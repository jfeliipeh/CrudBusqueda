using CrudBusqueda.Data.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrudBusqueda.Data.Service
{
    public interface ISearchService
    {
        Task<IEnumerable<Articulo>> GetAll();
        Task<IEnumerable<Articulo>> GetArticulosByNombre(string nombre);
        Task<IEnumerable<Articulo>> GetArticulosPorCategoria(string categoria);
        Task<IEnumerable<Articulo>> GetArticulosPorMarca(string marca);
    }
}