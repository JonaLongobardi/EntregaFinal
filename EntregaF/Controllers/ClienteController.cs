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
        public IActionResult GuardarForm(Clientes oClientes)
        {
            var respuesta = clientesDatos.Guardar(oClientes);

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
            var oClientes = clientesDatos.Obtener(id);

            return View(oClientes);
        }
        [HttpPost]
        public IActionResult Editar(Clientes oClientes)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = clientesDatos.Editar(oClientes);

            if (respuesta)
                return RedirectToAction("Listar");
            else
                return View();
        }

        public IActionResult Eliminar(int id)
        {
            var oClientes = clientesDatos.Eliminar(id);

            return View();
        }

        [HttpPost]

        public IActionResult Eliminar(Clientes oClientes)
        {
            var respuesta = clientesDatos.Editar(oClientes);

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
