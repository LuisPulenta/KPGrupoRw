namespace Common.Models.Responses
{
    public class UsuarioResponse
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Login { get; set; }
        public string Contrasena { get; set; }
        public byte Estado { get; set; }
        public int? HabilitaAPP { get; set; }
        public int? HabilitaFotos { get; set; }
        public string HabilitaFlotas { get; set; }
        public string Modulo { get; set; }
        public string CodigoCausante { get; set; }
        public bool EstadoInv { get; set; }
        public bool Compras { get; set; }
    }
}