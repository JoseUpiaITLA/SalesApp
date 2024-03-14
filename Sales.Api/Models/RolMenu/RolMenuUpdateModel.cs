using Sales.Api.Models.NewFolder;

namespace Sales.Api.Models.RolMenu
{
    public class RolMenuUpdateModel : RolMenuBaseModel
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
