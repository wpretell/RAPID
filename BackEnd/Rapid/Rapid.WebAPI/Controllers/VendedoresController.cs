using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Rapid.Domain.Services;
using Rapid.Entities.Models;

namespace Rapid.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendedoresController : ControllerBase
    {
        [HttpGet("ListarVendedores")]
        public List<Vendedor> ListarVendedores()
        {
            var oVendedoresService = new VendedoresService();
            return oVendedoresService.ListarVendedores();
        }
    }
}
