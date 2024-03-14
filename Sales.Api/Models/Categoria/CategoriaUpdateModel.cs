namespace Sales.Api.Models.Categoria
{
    public class CategoriaUpdateModel : CategoriaBaseModal
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
