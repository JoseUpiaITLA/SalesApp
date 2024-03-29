namespace SalesApp.Infraestructure.Models.Categoria
{
    public class CategoriaBaseModal : BaseModel
    {
        public string? descripcion { get; set; }
        public bool esActivo { get; set; }
    }
}
