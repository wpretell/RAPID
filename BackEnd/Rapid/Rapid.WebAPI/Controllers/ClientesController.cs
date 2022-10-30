using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapid.Data.DAO;
using Rapid.Entities.Models;

namespace Rapid.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpGet("ListarClientes")]
        public List<Cliente> ListarClientes()
        {
            var oClientesData = new ClientesData();
            return oClientesData.ListarClientes();
        }

        [HttpPost("ListarCliente")]
        public Cliente ListarCliente([FromBody] int IdCliente)
        {
            var oClientesData = new ClientesData();
            return oClientesData.ListarCliente(IdCliente);
        }

        [HttpPost("AgregarCliente")]
        public string AgregarCliente([FromBody] Cliente entidad)
        {
            var oClientesData = new ClientesData();
            return oClientesData.AgregarCliente(entidad);
        }

        [HttpPut("ModificarCliente")]
        public string ModificarCliente([FromBody] Cliente entidad)
        {
            var oClientesData = new ClientesData();
            return oClientesData.ModificarCliente(entidad);
        }

        [HttpDelete("EliminarCliente")]
        public string EliminarCliente([FromBody] int IdCliente)
        {
            var oClientesData = new ClientesData();
            return oClientesData.EliminarCliente(IdCliente);
        }


    }
}
