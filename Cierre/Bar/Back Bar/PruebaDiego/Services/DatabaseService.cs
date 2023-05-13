using AutoMapper;
using Dapper;
using Newtonsoft.Json;
using PruebaDiego.DataContext;
using PruebaDiego.Interfaces;
using PruebaDiego.Models.DataTransferObjects;
using PruebaDiego.Models.Input;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace PruebaDiego.Services
{
    public class DatabaseService : IDatabaseService
    {
        private readonly DapperContext _context;
        private readonly IMapper _mapper;

        public DatabaseService(DapperContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task BorrarRegistroInventario(string codigo)
        {
            using IDbConnection db = _context.CreateConnection();

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();


                string sqlQuery = @"DELETE FROM [dbo].[Inventario]
                                    WHERE Codigo = @codigo";

                DynamicParameters parameter = new DynamicParameters();

                parameter.Add("codigo",codigo, DbType.String);

                

                await db.ExecuteAsync(sqlQuery, parameter);

            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }






        }

        public async Task CreaUsuarioNuevo(string persona)
        {
            using IDbConnection db = _context.CreateConnection();

            UsuarioNuevo objPersona = JsonConvert.DeserializeObject<UsuarioNuevo>(persona);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string sqlQuery = @"INSERT INTO dbo.Usuarios
                                   (Nombre,Cedula,Contraseña,IdRol,Usuario)
                             VALUES
                                   (@Nombre,@Cedula,@Contraseña,@IdRol,@Usuario)";


                if (objPersona.IdRol == "Administrador")
                {
                    objPersona.IdRol = "1";
                }
                else if (objPersona.IdRol == "Cajero")
                {
                    objPersona.IdRol = "2";
                }
                else if (objPersona.IdRol == "Mesero")
                {
                    objPersona.IdRol = "3";
                }


                DynamicParameters parameter = new DynamicParameters();
               
               
                parameter.Add("Nombre", objPersona.Nombre, DbType.String);
                parameter.Add("Cedula", objPersona.Cedula, DbType.String);
                parameter.Add("Contraseña", objPersona.Contraseña, DbType.String);
                parameter.Add("IdRol", objPersona.IdRol, DbType.String);
                parameter.Add("Usuario", objPersona.Usuario, DbType.String);
              

                await db.ExecuteAsync(sqlQuery, parameter);

              
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public async Task <IList<Inventario>> GetInventario(string sede)
        {
            using IDbConnection db = _context.CreateConnection();

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string sqlQuery = @" select Codigo, Nombre, Producto, Cantidad, Fecha_Ingreso, Fecha_Salida, Sedes from Inventario
                                     where sedes = @sedes; ";

                var parameters = new DynamicParameters();

                parameters.Add("sedes", sede, DbType.String);
               

                var consultaInventario = await db.QueryAsync<InventarioDto>(sqlQuery, parameters);

                List<Inventario> consulta = _mapper.Map<List<Inventario>>(consultaInventario);

                return consulta;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

        }

        public async Task<Usuario> GetUsuarios(string idUsuario, string idContraseña)
        {
        using IDbConnection db = _context.CreateConnection();

        try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string sqlQuery = @"select Usuario, Contraseña, IdRol 
                                    from Usuarios 
                                    where Usuario = @Usuario 
                                    and Contraseña = @Contraseña ";

                var parameters = new DynamicParameters();

                parameters.Add("Usuario", idUsuario, DbType.String);
                parameters.Add("Contraseña", idContraseña, DbType.String);

                var consultaUsuarios = await db.QueryFirstOrDefaultAsync<UsuariosDto>(sqlQuery, parameters);

                Usuario Login = _mapper.Map<Usuario>(consultaUsuarios);

                return Login;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public async Task<Usuario> GetValidacionRol(string idUsuario, string idRol)
        {
            using IDbConnection db = _context.CreateConnection();

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

                string sqlQuery = @"select Usuario, IdRol 
                                    from Usuarios 
                                    where Usuario = @Usuario 
                                    and IdRol = @IdRol ";

                var parameters = new DynamicParameters();

                parameters.Add("Usuario", idUsuario, DbType.String);
                parameters.Add("IdRol", idRol, DbType.String);

                var consultaUsuarios = await db.QueryFirstOrDefaultAsync<UsuariosDto>(sqlQuery, parameters);

                Usuario Login = _mapper.Map<Usuario>(consultaUsuarios);
                return Login;
            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }
        }

        public  async Task InsertNuevoProducto(string inventarios)
        {
            using IDbConnection db = _context.CreateConnection();


            Inventario objInvent = JsonConvert.DeserializeObject<Inventario>(inventarios);

            try
            {
                if (db.State == ConnectionState.Closed)
                    db.Open();

             
                string sqlQuery = @"INSERT INTO [dbo].[Inventario]
                                   ([Codigo]
                                   ,[Nombre]
                                   ,[Producto]
                                   ,[Cantidad]
                                   ,[Fecha_Ingreso]
                                 
                                   ,[Sedes])
                             VALUES
                                   (@Codigo
                                   ,@Nombre
                                   ,@Producto
                                   ,@Cantidad
                                   ,@Fecha_Ingreso
                                   
                                   ,@Sedes)";

                DynamicParameters parameter = new DynamicParameters();
               


                parameter.Add("Fecha_Ingreso", DateTime.UtcNow.AddHours(-5), DbType.DateTime);
                parameter.Add("Codigo",objInvent.Codigo, DbType.String);
                parameter.Add("Nombre", objInvent.Nombre, DbType.String);
                parameter.Add("Producto", objInvent.Producto, DbType.String);
                parameter.Add("Cantidad", objInvent.Cantidad, DbType.String);
                parameter.Add("Sedes", objInvent.Sedes, DbType.String);

                await db.ExecuteAsync(sqlQuery, parameter);

            }
            finally
            {
                if (db.State == ConnectionState.Open)
                    db.Close();
            }

        }
    }
}