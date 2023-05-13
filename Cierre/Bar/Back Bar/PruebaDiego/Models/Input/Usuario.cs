using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaDiego.Models.Input
{
    public class Usuario
    {
        [JsonProperty("usuario")]
        [OpenApiProperty(Description = "Usuario")]
        public string Usuarios { get; set; }

        [JsonProperty("contraseña")]
        [OpenApiProperty(Description = "Contraseña")]
        public string Contraseña { get; set; }

        [JsonProperty("idRol")]
        [OpenApiProperty(Description = "Identificador de Rol")]
        public string IdRol { get; set; }



    }
}
