using Microsoft.Data.SqlClient;
using Rapid.Entities.Models;
using System.Data;

namespace Rapid.Data.DAO
{
    public class VendedoresData
    {
        public static List<Vendedor> ListarVendedores()
        {
            var lista = new List<Vendedor>();
            using (SqlConnection oConexion = new SqlConnection(ConexionBD.Instancia.ObtenerConexion()))
            {
                oConexion.Open();
                SqlCommand cmd = new SqlCommand("USP_LISTAR_VENDEDORES", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader drlector = cmd.ExecuteReader();


                while (drlector.Read())
                {
                    var oVendedor = new Vendedor();
                    oVendedor.IdVendedor = Convert.ToInt32(drlector["IdVendedor"]);
                    oVendedor.NombreVendedor = drlector["NombreVendedor"].ToString().Trim();
                    oVendedor.CorreoElectronico = drlector["CorreoElectronico"].ToString().Trim();
                    oVendedor.Celular = drlector["Celular"].ToString().Trim();
                    lista.Add(oVendedor);
                }
                oConexion.Close();
                drlector.Close();
            }
            return lista;
        }
    }
}
