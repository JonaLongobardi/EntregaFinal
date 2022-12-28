using EntregaF.Datos;
using EntregaF.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace EntregaF.Controllers
{
    public class AccesoController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login oLogin)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    var cn = new Conexion();
                    using (var connection = new SqlConnection(cn.getCadenaSQL()))
                    {
                        using (SqlCommand cmd = new("sp_login", connection))
                        {
                            connection.Open();
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@CORREO", SqlDbType.VarChar).Value = oLogin.CORREO;
                            cmd.Parameters.AddWithValue("@CONTRASENIA", SqlDbType.VarChar).Value = oLogin.CONTRASENIA;
                            cmd.ExecuteNonQuery();
                            SqlDataReader dr = cmd.ExecuteReader();
                            if (dr.Read())
                            {
                                Response.Cookies.Append("user", "Bienvenido " + oLogin.CORREO);
                                return RedirectToAction("Index", "Home");
                            }
                            else
                            {
                                ViewData["error"] = "Error de credenciales";
                            }
                        }
                    }
                    return RedirectToAction("Index", "Home");


                }
                catch (Exception o)
                {
                    string error = o.Message;
                    return View();
                }
            }

            else { return View(); }

        }


        public ActionResult Logout()
        {
            Response.Cookies.Delete("user");
            return RedirectToAction("Login", "Acceso");
        }





    }
}
