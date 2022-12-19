using System.ComponentModel.DataAnnotations;
namespace EntregaF.Models
{
    public class Empleados
    {
        public int EMPLEADOS_CODIGO { get; set; }
        public int TIPO_EMPLEADO { get; set; }
        public string APELLIDO_SUPERVISOR { get; set; }
        public string NOMBRE { get; set; }
        public string APELLIDO { get; set; }
        public int USUARIOS_CODIGO { get; set; }
    }
}
