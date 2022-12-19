using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class ProveedoresController : Controller
    {
        ProveedoresDatos proveedoresDatos = new ProveedoresDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = proveedoresDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Proveedores oProveedores)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = proveedoresDatos.Guardar(oProveedores);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int PROVEEDORES_COD)
        {
            var oProveedores = proveedoresDatos.Obtener(PROVEEDORES_COD);

            return View();
        }

        [HttpPost]

        public IActionResult Editar(Proveedores oProveedores)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = proveedoresDatos.Editar(oProveedores);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int PROVEEDORES_COD)
        {
            var oProveedores = proveedoresDatos.Eliminar(PROVEEDORES_COD);

            return View();
        }

        [HttpPost]

        public IActionResult Eliminar(Proveedores oProveedores)
        {
            var respuesta = proveedoresDatos.Editar(oProveedores);

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
