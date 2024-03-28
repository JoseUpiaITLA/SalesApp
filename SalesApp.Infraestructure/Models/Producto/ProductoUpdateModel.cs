namespace SalesApp.Infraestructure.Models.Producto
{
    public class ProductoUpdateModel : ProductoBaseModel
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
