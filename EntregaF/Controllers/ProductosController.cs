using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class ProductosController : Controller
    {
        ProductosDatos productosDatos = new ProductosDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = productosDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Productos oProductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = productosDatos.Guardar(oProductos);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int PRODUCTOS_COD)
        {
            var oProductos = productosDatos.Obtener(PRODUCTOS_COD);

            return View();
        }
        [HttpPost]
        public IActionResult Editar(Productos oProductos)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = productosDatos.Editar(oProductos);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int PRODUCTOS_COD)
        {
            var oProductos = productosDatos.Eliminar(PRODUCTOS_COD);

            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(Productos oProductos)
        {
            var respuesta = productosDatos.Editar(oProductos);

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
