namespace Sales.Api.Models.Menu
{
    public class MenuUpdateModal : MenuBaseModal
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
