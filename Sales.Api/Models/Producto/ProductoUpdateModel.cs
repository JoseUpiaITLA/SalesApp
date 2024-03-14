namespace Sales.Api.Models.Producto
{
    public class ProductoUpdateModel : ProductoBaseModel
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
