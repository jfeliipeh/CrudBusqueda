using CrudBusqueda.Data.Model;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudBusqueda.Data.Service
{
    public class SearchService : ISearchService
    {
        //Conexión a Sql Server
        private readonly SqlConnectionConfiguration _configuration;

        public SearchService(SqlConnectionConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<IEnumerable<Articulo>> GetAll()
        {
            using (var conn = new SqlConnection(_configuration.Value))
            {
                const string SelectArticulo = @"SELECT IdArticulo, Codigo, Nombre, Descripcion, Imagen, Categoria FROM dbo.Articulo";
                var resultArticulos = await conn.QueryAsync<Articulo>(SelectArticulo);
                return resultArticulos.ToList();
            }
        }

        //Filtrar por nombre
        public async Task<IEnumerable<Articulo>> GetArticulosByNombre(string nombre)
        {
            using (var connection = new SqlConnection(_configuration.Value))
            {
                const string sql = @"SELECT * FROM dbo.Articulo WHERE Nombre LIKE '%' + @Nombre + '%'";
                var result = await connection.QueryAsync<Articulo>(sql, new { nombre = @nombre });
                return result;
            }
        }
        //Filtrar por categoria
        public async Task<IEnumerable<Articulo>> GetArticulosPorCategoria(string categoria)
        {

            using (var connection = new SqlConnection(_configuration.Value))
            {

                const string articulos = @"SELECT * FROM dbo.Articulo WHERE Categoria LIKE '%' + @categoria + '%'";
                var articulosPorCategoria = await connection.QueryAsync<Articulo>(articulos, new { categoria = @categoria });
                return articulosPorCategoria;
            }
        }

        //Filtrar por color
        public async Task<IEnumerable<Articulo>> GetArticulosPorMarca(string marca)
        {
            using (var connection = new SqlConnection(_configuration.Value))
            {
                const string articulos = @"SELECT * FROM dbo.Articulo WHERE Marca LIKE '%' + @marca + '%'";
                var articulosPorMarca = await connection.QueryAsync<Articulo>(articulos, new { marca = @marca });
                return articulosPorMarca;
            }
        }
    }
}
