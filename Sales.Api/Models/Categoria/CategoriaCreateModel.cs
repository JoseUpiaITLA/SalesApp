namespace Sales.Api.Models.Categoria
{
    public class CategoriaCreateModel : CategoriaBaseModal
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }

    }
}
