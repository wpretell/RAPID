using Rapid.Data.DAO;
using Rapid.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rapid.Domain.Services
{
    public class ClientesService
    {
        public List<Cliente> ListarClientes()
        {
            return ClientesData.ListarClientes();
        }

        public Cliente ListarCliente(int IdCliente)
        {
            return ClientesData.ListarCliente(IdCliente);
        }

        public string AgregarCliente(Cliente entidad)
        {
            return ClientesData.AgregarCliente(entidad);

        }

        public string ModificarCliente(Cliente entidad)
        {
            return ClientesData.ModificarCliente(entidad);

        }

        public string EliminarCliente(int IdCliente)
        {
            return ClientesData.EliminarCliente(IdCliente);

        }

        public List<Direccion> ListarDirecciones(int IdDireccion)
        {
            return ClientesData.ListarDirecciones(IdDireccion);
        }

        public string AgregarDireccion(Direccion entidad)
        {
            return ClientesData.AgregarDireccion(entidad);

        }

        public string ModificarDireccion(Direccion entidad)
        {
            return ClientesData.ModificarDireccion(entidad);

        }

        public string EliminarDireccion(Direccion entidad)
        {
            return ClientesData.EliminarDireccion(entidad);

        }


    }
}
