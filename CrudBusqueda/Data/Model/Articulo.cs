﻿namespace CrudBusqueda.Data.Model
{
    public class Articulo
    {
        public int IdArticulo { get; set; }
        public int Codigo { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string Imagen { get; set; }
        public string Categoria { get; set; }
    }
}
