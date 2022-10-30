using Microsoft.Data.SqlClient;
using Rapid.Entities.Models;
using System.Data;

namespace Rapid.Data.DAO
{
    public class ClientesData
    {
        public static List<Cliente> ListarClientes()
        {
            var lista = new List<Cliente>();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion())) 
                {

                    oConexion.Open();
                    SqlCommand cmd = new SqlCommand("USP_LISTAR_CLIENTES", oConexion);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader drlector = cmd.ExecuteReader();


                    while (drlector.Read())
                    {
                        Cliente oCliente = new Cliente();
                        oCliente.IdCliente = Convert.ToInt32(drlector["IdCliente"]);
                        oCliente.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                        oCliente.NroDNI = drlector["NroDNI"].ToString().Trim();
                        oCliente.CorreoElectronico = drlector["CorreoElectronico"].ToString().Trim();
                        oCliente.NroCelular = drlector["NroCelular"].ToString().Trim();
                        oCliente.DireccionActiva = drlector["DireccionActiva"].ToString().Trim();
                        lista.Add(oCliente);
                    }
                    oConexion.Close();
                    drlector.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return lista;
        }

        public static Cliente ListarCliente(int IdCliente)
        {
            Cliente oCliente = new Cliente();
            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
                {
                    oConexion.Open();
                    SqlCommand cmd = new SqlCommand("USP_LISTAR_CLIENTE", oConexion);
                    cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = IdCliente;

                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader drlector = cmd.ExecuteReader();


                    while (drlector.Read())
                    {
                        oCliente.IdCliente = Convert.ToInt32(drlector["IdCliente"]);
                        oCliente.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                        oCliente.NroDNI = drlector["NroDNI"].ToString().Trim();
                        oCliente.CorreoElectronico = drlector["CorreoElectronico"].ToString().Trim();
                        oCliente.NroCelular = drlector["NroCelular"].ToString().Trim();
                        oCliente.DireccionActiva = drlector["DireccionActiva"].ToString().Trim();
                    }
                    oConexion.Close();
                    drlector.Close();
                }
            }
            catch (Exception)
            {
                throw;
            }
            return oCliente;
        }

        public static string AgregarCliente(Cliente entidad)
        {
            try
            {
                using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
                {
                    oConexion.Open();
                    SqlCommand cmd = new SqlCommand("USP_AGREGAR_CLIENTE", oConexion);
                    cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 200)).Value = entidad.NombreCompleto;
                    cmd.Parameters.Add(new SqlParameter("@NroDNI", SqlDbType.VarChar, 8)).Value = entidad.NroDNI;
                    cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", SqlDbType.VarChar, 200)).Value = entidad.CorreoElectronico;
                    cmd.Parameters.Add(new SqlParameter("@NroCelular", SqlDbType.VarChar, 9)).Value = entidad.NroCelular;
                    cmd.Parameters.Add(new SqlParameter("@DireccionActiva", SqlDbType.VarChar, 200)).Value = entidad.DireccionActiva;

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                    oConexion.Close();
                }
            }
            catch (Exception)
            {

                throw;
            }

            return "Registro Exitoso";

        }

        public static string ModificarCliente(Cliente entidad)
        {

            using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("USP_MODIFICAR_CLIENTE", oConexion);
                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
                cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 200)).Value = entidad.NombreCompleto;
                cmd.Parameters.Add(new SqlParameter("@NroDNI", SqlDbType.VarChar, 8)).Value = entidad.NroDNI;
                cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", SqlDbType.VarChar, 200)).Value = entidad.CorreoElectronico;
                cmd.Parameters.Add(new SqlParameter("@NroCelular", SqlDbType.VarChar, 9)).Value = entidad.NroCelular;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                oConexion.Close();
            }
            return "Modificación Exitosa";

        }

        public static string EliminarCliente(int IdCliente)
        {
            using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("USP_ELIMINAR_CLIENTE", oConexion);
                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = IdCliente;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                oConexion.Close();
            }
            return "Eliminación Exitosa";
        }

        public static List<Direccion> ListarDirecciones(int IdCliente)
        {
            var lista = new List<Direccion>();
            using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("USP_LISTAR_DIRECCIONES", oConexion);
                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = IdCliente;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drlector = cmd.ExecuteReader();
                while (drlector.Read())
                {
                    var oDireccion = new Direccion();
                    oDireccion.IdDireccion = Convert.ToInt32(drlector["IdDireccion"]);
                    oDireccion.IdCliente = IdCliente;
                    oDireccion.DireccionRegistro = drlector["DireccionRegistro"].ToString().Trim();
                    oDireccion.FechaRegistro = Convert.ToDateTime(drlector["FechaRegistro"]);
                    oDireccion.Activo = Convert.ToBoolean(drlector["Activo"]);
                    lista.Add(oDireccion);
                }
                oConexion.Close();
                drlector.Close();
            }
            return lista;
        }

        public static string AgregarDireccion(Direccion entidad)
        {
            using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("USP_AGREGAR_DIRECCION", oConexion);
                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
                cmd.Parameters.Add(new SqlParameter("@NuevaDireccion", SqlDbType.VarChar, 200)).Value = entidad.DireccionRegistro;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                oConexion.Close();
            }
            return "Registro Exitoso";

        }

        public static string ModificarDireccion(Direccion entidad)
        {
            using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("USP_MODIFICAR_DIRECCION", oConexion);
                cmd.Parameters.Add(new SqlParameter("@IdDireccion", SqlDbType.Int)).Value = entidad.IdDireccion;
                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
                cmd.Parameters.Add(new SqlParameter("@NuevaDireccion", SqlDbType.VarChar, 200)).Value = entidad.DireccionRegistro;
                cmd.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Bit, 9)).Value = entidad.Activo;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                oConexion.Close();
            }
            return "Modificación Exitosa";

        }

        public static string EliminarDireccion(Direccion entidad)
        {
            using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("USP_ELIMINAR_DIRECCION", oConexion);
                cmd.Parameters.Add(new SqlParameter("@IdDireccion", SqlDbType.Int)).Value = entidad.IdDireccion;
                cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
                cmd.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Bit, 9)).Value = entidad.Activo;

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                oConexion.Close();
            }
            return "Eliminación Exitosa";

        }


    }
}
