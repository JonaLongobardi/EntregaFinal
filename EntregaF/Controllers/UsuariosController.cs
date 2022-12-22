using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class UsuariosController : Controller
    {
        UsuariosDatos usuariosDatos = new UsuariosDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = usuariosDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Usuarios oUsuarios )
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var respuesta = usuariosDatos.Guardar(oUsuarios);

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
            var oUsuarios = usuariosDatos.Obtener(id);

            return View();
        }

        [HttpPost]

        public IActionResult Editar(Usuarios oUsuarios)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = usuariosDatos.Editar(oUsuarios);

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
            var oUsuarios = usuariosDatos.Eliminar(id);

            return View();
        }

        [HttpPost]

        public IActionResult Eliminar(Usuarios oUsuarios)
        {
            var respuesta = usuariosDatos.Editar(oUsuarios);

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
