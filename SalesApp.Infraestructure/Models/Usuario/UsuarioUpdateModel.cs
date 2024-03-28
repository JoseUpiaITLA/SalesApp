namespace SalesApp.Infraestructure.Models.Usuario
{
    public class UsuarioUpdateModel : UsuarioBaseModel
    {
        public DateTime? FechaMod { get; set; }
        public int? IdUsuarioMod { get; set; }
    }
}
