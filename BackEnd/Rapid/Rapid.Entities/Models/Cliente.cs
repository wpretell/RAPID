using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Entities.Models
{
    public class Cliente
    {
        public int IdCliente { get; set; }
        public string? NombreCompleto { get; set; }
        public string? NroDNI { get; set; }
        public string? CorreoElectronico { get; set; }
        public string? NroCelular { get; set; }
        public string? DireccionActiva { get; set; }
    }
}
