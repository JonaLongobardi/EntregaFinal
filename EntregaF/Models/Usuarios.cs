using System.ComponentModel.DataAnnotations;
namespace EntregaF.Models

{
    public class Usuarios
    {
        [Key]
        public int USUARIOS_CODIGO { get; set; }

        public string CORREO { get; set; }
      
        public string CONTRASENIA { get; set; }
      
        public bool MantenerseLogueado { get; set; }

        public string Rol_Usuario { get; set; }
    }
}
