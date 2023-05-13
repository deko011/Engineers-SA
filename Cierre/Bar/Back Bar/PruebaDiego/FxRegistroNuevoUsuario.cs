using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using FluentValidation;
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
using PruebaDiego.Models;
using PruebaDiego.Models.Input;
using PruebaDiego.Utils;

namespace PruebaDiego
{
    public class FxRegistroNuevoUsuario
    {
        private readonly IDatabaseService _serviceDatabase;
        private readonly IValidator<UsuarioNuevo> _servicioValidator;

        public FxRegistroNuevoUsuario(IDatabaseService databaseService, IValidator<UsuarioNuevo> servicioValidator)
        {
            _serviceDatabase = databaseService;
            _servicioValidator = servicioValidator;
        }

        [FunctionName(nameof(FxRegistroNuevoUsuario))]
        [FixedDelayRetry(3, "00:00:05")]
        [OpenApiOperation(operationId: "RegistroUsuarioNuevo", tags: new[] { "RegistroUsuarioNuevo" }, Description = "Insercion de persona nueva", Summary = "Insercion de persona nueva")]
        [OpenApiSecurity("function_key", SecuritySchemeType.ApiKey, Name = "code", In = OpenApiSecurityLocationType.Query)]
        [OpenApiRequestBody(contentType: "application/json", bodyType: typeof(UsuarioNuevo), Required = true, Description = "")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "text/json", bodyType: typeof(string), Description = "The OK response")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.Created, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Respuesta de Creacion")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.NoContent, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "No Content")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.BadRequest, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Bad Request")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.InternalServerError, contentType: "application/json", bodyType: typeof(ResponseResult), Description = "Error en el servicio")]
        public async Task<IActionResult> RegistroUsuarioNuevo(
            [HttpTrigger(AuthorizationLevel.Anonymous, "post", Route = "V1.0/RegistroUsuarioNuevo")] HttpRequest req)
        {
            try
            {
                var json = await req.ReadAsStringAsync();

                try
                {
                    UsuarioNuevo request = JsonConvert.DeserializeObject<UsuarioNuevo>(json);

                    try
                    {
                        await _serviceDatabase.CreaUsuarioNuevo(json);
                        
                        return HttpResponseHelper.Response(StatusCodes.Status201Created, new ResponseResult()
                        {
                            IsError = false,
                            Message = "Registro Usuario nuevo creada Exitosamente."
                        });
                    }
                    catch (Exception ex)
                    {
                        return HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message });
                    }
                }
                catch (Exception ex)
                {
                    return HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message });
                }
            }
            catch (Exception ex)
            {
                return Utils.HttpResponseHelper.Response(StatusCodes.Status500InternalServerError, new ResponseResult() { IsError = true, Message = ex.Message });
            }
        }
    }
}

