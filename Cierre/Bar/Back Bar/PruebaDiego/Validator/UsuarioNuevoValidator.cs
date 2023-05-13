using FluentValidation;
using Microsoft.Extensions.Configuration;
using PruebaDiego.Interfaces;
using PruebaDiego.Models.Input;

namespace PruebaDiego.Validator
{
    public class UsuarioNuevoValidator : AbstractValidator<UsuarioNuevo>
    {
        private readonly IDatabaseService _serviceDatabase;

        private readonly IConfiguration _configuration;
        public IConfiguration Configuration => _configuration;


        public UsuarioNuevoValidator(IDatabaseService serviceDatabase, IConfiguration configuration)
        {
            _serviceDatabase = serviceDatabase;
            _configuration = configuration;

            RuleFor(property => property.Nombre).NotNull().WithMessage("El campo Nombre no puede ser nulo");
            RuleFor(property => property.Cedula).NotNull().WithMessage("El campo Cedula no puede ser nulo");
            RuleFor(property => property.Usuario).NotNull().WithMessage("El Campo Usuario no puede ser nulo");
            RuleFor(property => property.Contraseña).NotNull().WithMessage("El campo Contraseña no puede ser nulo");
            RuleFor(property => property.IdRol).NotNull().WithMessage("El campo IdRol no puede ser nulo");
        }
    }
}
