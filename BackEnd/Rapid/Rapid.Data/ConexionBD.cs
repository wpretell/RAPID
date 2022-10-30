using Microsoft.Extensions.Configuration;

namespace Rapid.Data
{
    public class ConexionBD
    {
        private static ConexionBD instancia;
        public static ConexionBD Instancia
        {
            get
            {
                if (instancia == null)
                    instancia = new ConexionBD();
                return instancia;
            }
        }

        protected ConexionBD()
        { }


        public string ObtenerConexion()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder()
             .SetBasePath(Directory.GetCurrentDirectory())
             .AddJsonFile("appsettings.json");

            IConfiguration Configuration = builder.Build();
            return Configuration["ConnectionStrings:DefaultConnection"];
        }
    }
}
