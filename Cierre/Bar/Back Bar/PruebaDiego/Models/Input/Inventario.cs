using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Newtonsoft.Json;
using System;

namespace PruebaDiego.Models.Input
{
    public class Inventario
    {
        [JsonProperty("codigo")]
        [OpenApiProperty(Description = "Codigo del Producto")]
        public string Codigo { get; set; }

        [JsonProperty("nombre")]
        [OpenApiProperty(Description = "Nombre del Producto")]
        public string Nombre { get; set; }

        [JsonProperty("producto")]
        [OpenApiProperty(Description = "Tipo de producto")]
        public string Producto { get; set; }

        [JsonProperty("cantidad")]
        [OpenApiProperty(Description = "Cantidad de producto")]
        public string Cantidad { get; set; }

        [JsonProperty("fecha_ingreso")]
        [OpenApiProperty(Description = "Fecha de ingreso del produicto a inventario ")]
        public DateTime Fecha_Ingreso { get; set; }

        [JsonProperty("fecha_salida")]
        [OpenApiProperty(Description = "Fecha de salida del produicto a inventario ")]
        public DateTime Fecha_Salida { get; set; }

        [JsonProperty("sedes")]
        [OpenApiProperty(Description = "Sedes")]
        public string Sedes { get; set; }
    }
}
