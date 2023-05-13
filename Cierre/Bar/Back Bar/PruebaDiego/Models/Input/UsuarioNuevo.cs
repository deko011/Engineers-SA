using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDiego.Models.Input
{
    public class UsuarioNuevo
    {
        [JsonProperty("nombre")]
        [OpenApiProperty(Description = "Nombre de la Persona")]
        public string Nombre { get; set; }

        [JsonProperty("cedula")]
        [OpenApiProperty(Description = "Nummero de Cedula")]
        public string Cedula { get; set; }

        [JsonProperty("usuario")]
        [OpenApiProperty(Description = "Usuario de logueo")]
        public string Usuario { get; set; }

        [JsonProperty("contraseña")]
        [OpenApiProperty(Description = "Contraseña de logueo")]
        public string Contraseña { get; set; }

        [JsonProperty("rol")]
        [OpenApiProperty(Description = "Rol de la persona ")]
        public string IdRol { get; set; }
    }
}
