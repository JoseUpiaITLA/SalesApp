namespace SalesApp.Infraestructure.Models.Categoria
{
    public class CategoriaCreateModel : CategoriaBaseModal
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }

    }
}
