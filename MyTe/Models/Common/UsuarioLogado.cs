namespace MyTe.Models.Common
{
    public class UsuarioLogado
    {
        public UsuarioLogado()
        {
            IniciarPropriedades();
        }
        public void IniciarPropriedades()
        {
            IdUsuario = null;
            Usuario = null;
            NomeFuncionario = null;
        }
        public string? IdUsuario { get; set; }
        public string? Usuario { get; set; }
        public string? NomeFuncionario { get; set; }
    }
}
