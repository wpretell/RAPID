using Microsoft.Data.SqlClient;
using Rapid.Entities.Models;
using System.Data;

namespace Rapid.Data.DAO
{
    public class VendedoresData
    {
        public List<Vendedor> ListarVendedores()
        {
            var lista = new List<Vendedor>();
            string cadenaConexion = "Data Source=MORALES\\SQL2012;DataBase=BD_Empresa;Integrated Security=true";
            SqlConnection cn = new SqlConnection(cadenaConexion);
            cn.Open();
            SqlCommand cmd = new SqlCommand("USP_LISTAR_VENDEDORES", cn);
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
            return lista;
        }
    }
}
