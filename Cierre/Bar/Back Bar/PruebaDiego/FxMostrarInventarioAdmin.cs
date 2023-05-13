using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using PruebaDiego.Interfaces;
using PruebaDiego.Models;
using PruebaDiego.Models.Input;
using PruebaDiego.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace PruebaDiego
{
    public class FxMostrarInventarioAdmin
    {
        public readonly IDatabaseService _serviceDatabase;


        public FxMostrarInventarioAdmin(IDatabaseService serviceDatabase)
        {
            _serviceDatabase = serviceDatabase;

        }


        [FunctionName("FxMostrarInventarioAdmin")]
        [FixedDelayRetry(3, "00:00:05")]
        [OpenApiOperation(operationId: "ListMostrarInventarioAdmin", tags: new[] { "ListMostrarInventarioAdmin" }, Description = "Inventario de Admin", Summary = "Inventario de Admin")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]// Documentacion de parametros en path, query etc.
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(Usuario), Required = true, Description = "Ejemplo de Request")]//Documentacion de los parametros en el Body
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Respuesta de Creacion")] //Utiice solo las respuestas que utilice en su end point
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NoContent, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "No Content")] //Utiice solo las respuestas que utilice en su end point
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Bad Request")] //Utiice solo las respuestas que utilice en su end point
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Error en el servicio")] //Utiice solo las respuestas que utilice en su end point
        public async Task<IActionResult> ListMostrarInventarioAdmin(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "V1.0/InventarioAdmin/{sede}")] HttpRequest req, string sede)
        {
            try
            {
                IList<Inventario> inventarios = await _serviceDatabase.GetInventario(sede);
                if (!inventarios.Any())
                    return HttpResponseHelper.HttpExplicitNoContent();
                return HttpResponseHelper.SuccessfulObjectResult(inventarios);
            }
            catch (Exception ex)
            {
                return HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message });
            }

        }

    }
}

