namespace SistemaLogin.Modelos
{
    public class Usuario
    {
        public string NombreUsuario { get; private set; }
        public string Contraseña { get; private set; }

        public Usuario(string nombreUsuario, string contraseña)
        {
            NombreUsuario = nombreUsuario;
            Contraseña = contraseña;
        }

        public bool ValidarCredenciales(string nombreUsuario, string contraseña)
        {
            return NombreUsuario == nombreUsuario && Contraseña == contraseña;
        }
    }
}
