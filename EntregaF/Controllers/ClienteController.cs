using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class ClienteController : Controller
    {
        ClientesDatos clientesDatos = new ClientesDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = clientesDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Clientes datos)
        {
            var respuesta = clientesDatos.Guardar(datos);

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
            var oCliente = clientesDatos.Obtener(id);

            return View();
        }
        [HttpPost]
        public IActionResult Editar(Clientes oCliente)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = clientesDatos.Editar(oCliente);

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
            var oCliente = clientesDatos.Eliminar(id);

            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(Clientes oCliente)
        {
            var respuesta = clientesDatos.Editar(oCliente);

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
