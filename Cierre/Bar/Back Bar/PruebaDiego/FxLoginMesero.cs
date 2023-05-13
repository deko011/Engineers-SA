using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using PruebaDiego.Interfaces;
using PruebaDiego.Models.Input;
using PruebaDiego.Models;
using PruebaDiego.Utils;

namespace PruebaDiego
{
    public class FxLoginMesero
    {
        public readonly IDatabaseService _serviceDatabase;


        public FxLoginMesero(IDatabaseService serviceDatabase)
        {
            _serviceDatabase = serviceDatabase;

        }


        [FunctionName("FxLoginMesero")]
        [FixedDelayRetry(3, "00:00:05")]
        [OpenApiOperation(operationId: "ListLoginMesero", tags: new[] { "ListLoginMesero" }, Description = "Login de Mesero", Summary = "Login de Mesero")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiParameter(name: "name", In = ParameterLocation.Query, Required = true, Type = typeof(string), Description = "The **Name** parameter")]// Documentacion de parametros en path, query etc.
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(Usuario), Required = true, Description = "Ejemplo de Request")]//Documentacion de los parametros en el Body
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(string), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Respuesta de Creacion")] //Utiice solo las respuestas que utilice en su end point
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NoContent, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "No Content")] //Utiice solo las respuestas que utilice en su end point
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Bad Request")] //Utiice solo las respuestas que utilice en su end point
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Error en el servicio")] //Utiice solo las respuestas que utilice en su end point
        public async Task<IActionResult> ListLoginMesero(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "V1.0/LoginMesero/{idUsuario}/{idContraseña}/{idRol}")] HttpRequest req, string idUsuario, string idContraseña, string idRol)
        {
            try
            {

                Usuario usuario = await _serviceDatabase.GetUsuarios(idUsuario, idContraseña);

                if (usuario == null)
                    return HttpResponseHelper.HttpExplicitNoContent();

                if (usuario.IdRol != "3")

                    return HttpResponseHelper.Response(StatusCodes.Status401Unauthorized, new ResponseResult() { IsError = true, Message = "El usuario no tiene permisos de administrador" });

                Usuario rol = await _serviceDatabase.GetValidacionRol(idUsuario, idRol);



                return HttpResponseHelper.SuccessfulObjectResult(rol);


            }
            catch (Exception ex)
            {
                return HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message });
            }
        }
    }
}

