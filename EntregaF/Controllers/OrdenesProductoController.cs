using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class OrdenesProductoController : Controller
    {
        OrdenesProductosDatos ordenesproductosDatos = new OrdenesProductosDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = ordenesproductosDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(OrdenesProducto oOrdenesProductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ordenesproductosDatos.Guardar(oOrdenesProductos);

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
            var oOrdenesProductos = ordenesproductosDatos.Obtener(id);

            return View(oOrdenesProductos);
        }

        [HttpPost]

        public IActionResult Editar(OrdenesProducto oOrdenesProductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = ordenesproductosDatos.Editar(oOrdenesProductos);

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
            var oOrdenesProductos = ordenesproductosDatos.Eliminar(id);

            return View();
        }

        [HttpPost]

        public IActionResult Eliminar(OrdenesProducto oOrdenesProductos)
        {
            var respuesta = ordenesproductosDatos.Editar(oOrdenesProductos);

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
