using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapid.Domain.Services;
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
            var oClientesService = new ClientesService();
            return oClientesService.ListarClientes();
        }

        [HttpGet("ListarCliente/{IdCliente}")]
        public Cliente ListarCliente(int IdCliente)
        {
            var oClientesService = new ClientesService();
            return oClientesService.ListarCliente(IdCliente);
        }

        [HttpPost("AgregarCliente")]
        public string AgregarCliente([FromBody] Cliente entidad)
        {
            var oClientesService = new ClientesService();
            return oClientesService.AgregarCliente(entidad);
        }

        [HttpPut("ModificarCliente")]
        public string ModificarCliente([FromBody] Cliente entidad)
        {
            var oClientesService = new ClientesService();
            return oClientesService.ModificarCliente(entidad);
        }

        [HttpDelete("EliminarCliente")]
        public string EliminarCliente([FromBody] int IdCliente)
        {
            var oClientesService = new ClientesService();
            return oClientesService.EliminarCliente(IdCliente);
        }

        [HttpGet("ListarDirecciones/{IdDireccion}")]
        public List<Direccion> ListarDirecciones(int IdDireccion)
        {
            var oClientesService = new ClientesService();
            return oClientesService.ListarDirecciones(IdDireccion);
        }

        [HttpPost("AgregarDireccion")]
        public string AgregarDireccion([FromBody] Direccion entidad)
        {
            var oClientesService = new ClientesService();
            return oClientesService.AgregarDireccion(entidad);
        }

        [HttpPut("ModificarDireccion")]
        public string ModificarDireccion([FromBody] Direccion entidad)
        {
            var oClientesService = new ClientesService();
            return oClientesService.ModificarDireccion(entidad);
        }

        [HttpDelete("EliminarDireccion")]
        public string EliminarDireccion([FromBody] Direccion entidad)
        {
            var oClientesService = new ClientesService();
            return oClientesService.EliminarDireccion(entidad);
        }


    }
}
