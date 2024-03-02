namespace Sales.Api.Models.Categoria
{
    public class CategoriaBaseModal : BaseModel
    {
        public string? Descripcion { get; set; }
        public bool EsActivo { get; set; }
    }
}
