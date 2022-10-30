using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Entities.Models
{
    public class Vendedor
    {
        public int IdVendedor { get; set; }
        public string? NombreVendedor { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? Celular { get; set; }
    }
}
