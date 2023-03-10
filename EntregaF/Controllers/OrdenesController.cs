using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class OrdenesController : Controller
    {
        OrdenesDatos ordenesDatos = new OrdenesDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = ordenesDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Ordenes oOrdenes)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ordenesDatos.Guardar(oOrdenes);

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
            var oOrdenes = ordenesDatos.Obtener(id);

            return View(oOrdenes);
        }

        [HttpPost]

        public IActionResult Editar(Ordenes oOrdenes)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ordenesDatos.Editar(oOrdenes);

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
            var oOrdenes = ordenesDatos.Eliminar(id);

            return View();
        }

        [HttpPost]

        public IActionResult Eliminar(Ordenes oOrdenes)
        {
            var respuesta = ordenesDatos.Editar(oOrdenes);

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
