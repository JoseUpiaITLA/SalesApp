namespace SalesApp.Infraestructure.Models.RolMenu
{
    public class RolMenuBaseModel : BaseModel
    {
        public int? IdRol { get; set; }
        public int? IdMenu { get; set; }
        public bool EsActivo { get; set; }
    }
}
