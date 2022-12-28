using System.Data.SqlClient;
using System.Data;
using EntregaF.Models;
using EntregaF.Datos;

namespace EntregaF.Datos
{
    public class ProductosDatos
    {
        public List<Productos> Listar()
        {
            var oLista = new List<Productos>();
            var cn = new Conexion();
            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();

                SqlCommand cmd = new SqlCommand("mostrarPRODUCTOS", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new Productos()
                        {
                            PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]),
                            PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"]),
                            NOMBRE = dr["NOMBRE"].ToString(),
                            PRECIO = Convert.ToInt32(dr["PRECIO"]),
                            STOCK = Convert.ToInt32(dr["STOCK"]),
                        });
                    }
                }
            }
            return oLista;
        }

        public Productos Obtener(int PRODUCTOS_COD)
        {
            var oProductos = new Productos();
            var cn = new Conexion();

            using (var connection = new SqlConnection(cn.getCadenaSQL()))
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand("obtenerPRODUCTOS", connection);
                cmd.Parameters.AddWithValue("PRODUCTOS_COD", PRODUCTOS_COD);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oProductos.PRODUCTOS_COD = Convert.ToInt32(dr["PRODUCTOS_COD"]);
                        oProductos.PROVEEDORES_COD = Convert.ToInt32(dr["PROVEEDORES_COD"]);
                        oProductos.NOMBRE = dr["NOMBRE"].ToString();
                        oProductos.PRECIO = Convert.ToInt32(dr["PRECIO"]);
                        oProductos.STOCK = Convert.ToInt32(dr["STOCK"]);
                        
                    }
                }
            }
            return oProductos;
        }

        public bool Guardar(Productos oProductos)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("guardarPRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("PROVEEDORES_COD", oProductos.PROVEEDORES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oProductos.NOMBRE);
                    cmd.Parameters.AddWithValue("PRECIO", oProductos.PRECIO);
                    cmd.Parameters.AddWithValue("STOCK", oProductos.STOCK);
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
        public bool Editar(Productos oProductos)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("editarPRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", oProductos.PRODUCTOS_COD);
                    cmd.Parameters.AddWithValue("PROVEEDORES_COD", oProductos.PROVEEDORES_COD);
                    cmd.Parameters.AddWithValue("NOMBRE", oProductos.NOMBRE);
                    cmd.Parameters.AddWithValue("PRECIO", oProductos.PRECIO);
                    cmd.Parameters.AddWithValue("STOCK", oProductos.STOCK);
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
        public bool Eliminar(int PRODUCTOS_COD)
        {
            bool respuesta;

            try
            {
                var cn = new Conexion();
                using (var connection = new SqlConnection(cn.getCadenaSQL()))
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("eliminarPRODUCTOS", connection);
                    cmd.Parameters.AddWithValue("PRODUCTOS_COD", PRODUCTOS_COD);
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
