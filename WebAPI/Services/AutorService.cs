using Dapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;
using WebAPI.Context;

namespace WebAPI.Services
{
    public class AutorService : IAutorService
    {
        private readonly ApplicationDbContext _context;

        public AutorService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Response<List<Autor>>> GetAutores()
        {
            try
            {
                List<Autor> response = new List<Autor>();
                var result = await _context.Database.GetDbConnection().QueryAsync<Autor>("spGetAutores", new {}, commandType: CommandType.StoredProcedure );
                response = result.ToList();

                return new Response<List<Autor>>(response);
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrio un error :c" +  ex.Message);
            }
        }

        public async Task<Response<Autor>> Crear(Autor a)
        {
            try
            {
                Autor result = new Autor();
                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spCrearAutor", new { a.Nombre, a.Nacionalidad }, commandType: CommandType.StoredProcedure )).FirstOrDefault();

                return new Response<Autor> (result);
            }
            catch(Exception ex) 
            {
                throw new Exception("Ocurrio un error :c" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Actualizar(int pkAutor, Autor a)
        {
            try
            {
                Autor result = new Autor();
                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spActualizarAutor", new { pkAutor, a.Nombre, a.Nacionalidad, }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error :c" + ex.Message);
            }
        }

        public async Task<Response<Autor>> Eliminar(int pkAutor)
        {
            try
            {
                Autor result = new Autor();
                result = (await _context.Database.GetDbConnection().QueryAsync<Autor>("spEliminarAutor", new { pkAutor }, commandType: CommandType.StoredProcedure)).FirstOrDefault();

                return new Response<Autor>(result);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error :c" + ex.Message);
            }
        }

    }
}
