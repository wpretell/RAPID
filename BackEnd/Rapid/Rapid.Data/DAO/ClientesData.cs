using Microsoft.Data.SqlClient;
using Rapid.Entities.Models;
using System.Data;

namespace Rapid.Data.DAO
{
    public class ClientesData
    {
        public List<Cliente> ListarClientes()
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

        public Cliente ListarCliente(int IdCliente)
        {
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_CLIENTE", cn);
            cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = IdCliente;

            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();

            Cliente oCliente = new Cliente();
            while (drlector.Read())
            {
                oCliente.IdCliente = Convert.ToInt32(drlector["IdCliente"]);
                oCliente.NombreCompleto = drlector["NombreCompleto"].ToString().Trim();
                oCliente.NroDNI = drlector["NroDNI"].ToString().Trim();
                oCliente.CorreoElectronico = drlector["CorreoElectronico"].ToString().Trim();
                oCliente.NroCelular = drlector["NroCelular"].ToString().Trim();
                oCliente.DireccionActiva = drlector["DireccionActiva"].ToString().Trim();
            }
            return oCliente;
        }

        public string AgregarCliente(Cliente entidad)
        {
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_AGREGAR_CLIENTE", cn);
            cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 200)).Value = entidad.NombreCompleto;
            cmd.Parameters.Add(new SqlParameter("@NroDNI", SqlDbType.VarChar, 8)).Value = entidad.NroDNI;
            cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", SqlDbType.VarChar, 200)).Value = entidad.CorreoElectronico;
            cmd.Parameters.Add(new SqlParameter("@NroCelular", SqlDbType.VarChar, 9)).Value = entidad.NroCelular;
            cmd.Parameters.Add(new SqlParameter("@DireccionActiva", SqlDbType.VarChar, 200)).Value = entidad.DireccionActiva;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Registro Exitoso";

        }

        public string ModificarCliente(Cliente entidad)
        {
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_MODIFICAR_CLIENTE", cn);
            cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
            cmd.Parameters.Add(new SqlParameter("@NombreCompleto", SqlDbType.VarChar, 200)).Value = entidad.NombreCompleto;
            cmd.Parameters.Add(new SqlParameter("@NroDNI", SqlDbType.VarChar, 8)).Value = entidad.NroDNI;
            cmd.Parameters.Add(new SqlParameter("@CorreoElectronico", SqlDbType.VarChar, 200)).Value = entidad.CorreoElectronico;
            cmd.Parameters.Add(new SqlParameter("@NroCelular", SqlDbType.VarChar, 9)).Value = entidad.NroCelular;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Modificación Exitosa";

        }

        public string EliminarCliente(int IdCliente)
        {
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ELIMINAR_CLIENTE", cn);
            cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = IdCliente;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Eliminación Exitosa";

        }

        public List<Direccion> ListarDirecciones(int IdCliente)
        {
            var lista = new List<Direccion>();
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_DIRECCIONES", cn);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader drlector = cmd.ExecuteReader();


            while (drlector.Read())
            {
                var oDireccion = new Direccion();
                oDireccion.IdDireccion = Convert.ToInt32(drlector["IdDireccion"]);
                oDireccion.IdCliente = Convert.ToInt32(drlector["IdCliente"]);
                oDireccion.DireccionRegistro = drlector["NombreCompleto"].ToString().Trim();
                oDireccion.FechaRegistro = Convert.ToDateTime(drlector["FechaNacimiento_Empleado"]);
                oDireccion.Activo = Convert.ToBoolean(drlector["CorreoElectronico"]);
                lista.Add(oDireccion);
            }
            return lista;
        }

        public string AgregarDireccion(Direccion entidad)
        {
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_AGREGAR_DIRECCION", cn);
            cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
            cmd.Parameters.Add(new SqlParameter("@NuevaDireccion", SqlDbType.VarChar, 200)).Value = entidad.DireccionRegistro;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Registro Exitoso";

        }

        public string ModificarDireccion(Direccion entidad)
        {
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_MODIFICAR_DIRECCION", cn);
            cmd.Parameters.Add(new SqlParameter("@IdDireccion", SqlDbType.Int)).Value = entidad.IdDireccion;
            cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
            cmd.Parameters.Add(new SqlParameter("@NuevaDireccion", SqlDbType.VarChar, 200)).Value = entidad.DireccionRegistro;
            cmd.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Bit, 9)).Value = entidad.Activo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Modificación Exitosa";

        }

        public string EliminarDireccion(Direccion entidad)
        {
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_ELIMINAR_DIRECCION", cn);
            cmd.Parameters.Add(new SqlParameter("@IdDireccion", SqlDbType.Int)).Value = entidad.IdDireccion;
            cmd.Parameters.Add(new SqlParameter("@IdCliente", SqlDbType.Int)).Value = entidad.IdCliente;
            cmd.Parameters.Add(new SqlParameter("@Activo", SqlDbType.Bit, 9)).Value = entidad.Activo;

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
            return "Eliminación Exitosa";

        }


    }
}
