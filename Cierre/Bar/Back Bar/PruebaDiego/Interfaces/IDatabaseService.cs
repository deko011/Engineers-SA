using PruebaDiego.Models.Input;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PruebaDiego.Interfaces
{
    public interface IDatabaseService
    {
        public Task<Usuario> GetUsuarios(string idUsuario, string idContraseña);

        public  Task <Usuario> GetValidacionRol(string idUsuario, string idRol);

        public Task CreaUsuarioNuevo(string persona);

        public Task<IList<Inventario>> GetInventario(string sede);

        public Task InsertNuevoProducto(string inventarios);

        public Task BorrarRegistroInventario(string codigo);

       
    }
}