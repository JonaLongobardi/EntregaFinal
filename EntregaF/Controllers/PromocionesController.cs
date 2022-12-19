﻿using EntregaDef.Datos;
using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;

namespace EntregaF.Controllers
{
    public class PromocionesController : Controller
    {
        PromocionesDatos promocionesDatos = new PromocionesDatos();

        //Mostrar lista de clientes
        public IActionResult Listar()
        {
            var oLista = promocionesDatos.Listar();
            return View(oLista);
        }
        public IActionResult GuardarForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult GuardarForm(Promociones oPromociones)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = promocionesDatos.Guardar(oPromociones);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Editar(int PROMOCIONES_CODIGO)
        {
            var oPromociones = promocionesDatos.Obtener(PROMOCIONES_CODIGO);

            return View();
        }
        [HttpPost]
        public IActionResult Editar(Promociones oPromociones)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta = promocionesDatos.Editar(oPromociones);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            {
                return View();
            }
        }

        public IActionResult Eliminar(int PROMOCIONES_CODIGO)
        {
            var oPromociones = promocionesDatos.Eliminar(PROMOCIONES_CODIGO);

            return View();
        }
        [HttpPost]
        public IActionResult Eliminar(Promociones oPromociones)
        {
            var respuesta = promocionesDatos.Editar(oPromociones);

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
