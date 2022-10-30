using Rapid.Data.DAO;
using Rapid.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Domain.Services
{
    public class VendedoresService
    {
        public List<Vendedor> ListarVendedores()
        {
            return VendedoresData.ListarVendedores();
        }
    }
}
