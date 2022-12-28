using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class EmpleadosController : Controller
    {
        EmpleadosDatos empleadosDatos = new EmpleadosDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = empleadosDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Empleados oEmpleados)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = empleadosDatos.Guardar(oEmpleados);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int id)
        {
            var oEmpleados = empleadosDatos.Obtener(id);

            return View(oEmpleados);
        }
        [HttpPost]
        public IActionResult Editar(Empleados oEmpleados)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = empleadosDatos.Editar(oEmpleados);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int id)
        {
            var oEmpleados = empleadosDatos.Eliminar(id);

            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(Empleados oEmpleados)
        {
            var respuesta = empleadosDatos.Editar(oEmpleados);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }
    }
}
