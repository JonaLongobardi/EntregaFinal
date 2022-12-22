using System.Data;
using EntregaF.Models;
using System.Data.SqlClient;

namespace EntregaF.Datos
{
    public class CategoriasDatos
    {
        public List<Categorias> Listar()
        {
            var oLista = new List<Categorias>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarCATEGORIAS", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Categorias()
                        {
                            CATEGORIA_COD = Convert.ToInt32(dr["CATEGORIA_COD"]),
                            DETALLE = dr["DETALLE"].ToString(),
                        });
                    }
                }
            }
            return oLista;
        }

        public Categorias Obtener(int CATEGORIA_COD)
        {
            var oCategorias = new Categorias();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerCATEGORIAS", connection);
                cmd.Parameters.AddWithValue("CATEGORIA_COD", CATEGORIA_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oCategorias.CATEGORIA_COD = Convert.ToInt32(dr["CATEGORIA_COD"]);
                        oCategorias.DETALLE = dr["DETALLE"].ToString();
                    }
                }
            }
            return oCategorias;
        }

        public bool Guardar(Categorias oCategorias)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarCATEGORIAS", connection);
                    cmd.Parameters.AddWithValue("DETALLE", oCategorias.DETALLE);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool Editar(Categorias oCategorias)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarCATEGORIAS", connection);
                    cmd.Parameters.AddWithValue("CATEGORIA_COD", oCategorias.CATEGORIA_COD);
                    cmd.Parameters.AddWithValue("DETALLE", oCategorias.DETALLE);
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
        public bool Eliminar(int CATEGORIA_COD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarCATEGORIAS", connection);
                    cmd.Parameters.AddWithValue("CATEGORIA_COD", CATEGORIA_COD);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;
        }
    }
}
