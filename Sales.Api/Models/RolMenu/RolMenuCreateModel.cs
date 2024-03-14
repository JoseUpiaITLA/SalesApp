using Sales.Api.Models.NewFolder;

namespace Sales.Api.Models.RolMenu
{
    public class RolMenuCreateModel : RolMenuBaseModel
    {
        public DateTime FechaRegistro { get; set; }
        public int IdUsuarioCreacion { get; set; }
    }
}
