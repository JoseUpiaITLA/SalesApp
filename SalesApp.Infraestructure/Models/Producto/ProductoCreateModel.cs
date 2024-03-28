namespace SalesApp.Infraestructure.Models.Producto
{
    public class ProductoCreateModel : ProductoBaseModel
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
