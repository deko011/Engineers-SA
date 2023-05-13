using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.OpenApi.Models;
using PruebaDiego.Interfaces;
using PruebaDiego.Models;
using PruebaDiego.Utils;
using System;
using System.Net;
using System.Threading.Tasks;

namespace PruebaDiego
{
    public class FxEliminarRegistroInventario
    {
        private readonly IDatabaseService _serviceDatabase;


        public FxEliminarRegistroInventario(IDatabaseService serviceDatabase)
        {
            _serviceDatabase = serviceDatabase;

        }


        [FunctionName("FxEliminarRegistroInventario")]
    
        [OpenApiOperation(operationId: "EliminarRegistroInventario", tags: new[] { "EliminarRegistroInventario" }, Description = "Eliminar un producto", Summary = "Eliminar un producto")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(string), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Respuesta de Creacion")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NoContent, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "No Content")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Bad Request")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Error en el servicio")]

        public async Task<IActionResult> EliminarRegistroInventario(
           [HttpTrigger(AuthorizationLevel.Function, "delete", Route = "V1.0/EliminarRegistroInventario/{codigo}")] HttpRequest req, string codigo)


        {
            

                try
                {
                    await _serviceDatabase.BorrarRegistroInventario(codigo);

                    return HttpResponseHelper.Response(StatusCodes.Status201Created, new ResponseResult()
                    {
                        IsError = false,
                        Message = "Registro eliminado Exitosamente."
                    });
                }
                catch (Exception ex)
                {
                    return HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message });
                }

            







        }
    }
}

