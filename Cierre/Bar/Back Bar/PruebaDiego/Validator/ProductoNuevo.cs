using FluentValidation;
using Microsoft.Extensions.Configuration;
using PruebaDiego.Interfaces;
using PruebaDiego.Models.Input;

namespace PruebaDiego.Validator
{
    public class ProductoNuevo : AbstractValidator<Inventario>
    {
        private readonly IDatabaseService _serviceDatabase;

        private readonly IConfiguration _configuration;
        public IConfiguration Configuration => _configuration;


        public ProductoNuevo(IDatabaseService serviceDatabase, IConfiguration configuration)
        {
            _serviceDatabase = serviceDatabase;
            _configuration = configuration;

            RuleFor(property => property.Nombre).NotNull().WithMessage("El campo Nombre no puede ser nulo");
            RuleFor(property => property.Sedes).NotNull().WithMessage("El campo Cedula no puede ser nulo");
            RuleFor(property => property.Producto).NotNull().WithMessage("El Campo Usuario no puede ser nulo");
            RuleFor(property => property.Fecha_Ingreso).NotNull().WithMessage("El campo Contraseña no puede ser nulo");
            RuleFor(property => property.Cantidad).NotNull().WithMessage("El campo IdRol no puede ser nulo");
            RuleFor(property => property.Codigo).NotNull().WithMessage("El campo IdRol no puede ser nulo");
       
        }
    
    }
}
