namespace Sales.Api.Models.NewFolder
{
    public class RolMenuBaseModel : BaseModel
    {
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }
        public bool EsActivo { get; set; }
    }
}
