using FluentValidation;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using PruebaDiego.DataContext;
using PruebaDiego.Interfaces;
using PruebaDiego.Models.Input;
using PruebaDiego.Services;
using PruebaDiego.Validator;

[assembly: FunctionsStartup(typeof(PruebaDiego.Startup))]

namespace PruebaDiego
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
         



            builder.Services.AddSingleton<DapperContext>();
            builder.Services.AddAutoMapper(typeof(Startup));
            builder.Services.AddMvcCore().AddNewtonsoftJson(jsonOptions =>
            {
                jsonOptions.SerializerSettings.NullValueHandling = NullValueHandling.Ignore; 
            });

            builder.Services.AddTransient<IDatabaseService, DatabaseService>();
            builder.Services.AddScoped<IValidator<UsuarioNuevo>, UsuarioNuevoValidator>();
            builder.Services.AddScoped<IValidator<Inventario>, ProductoNuevo>();










        }
    }
}