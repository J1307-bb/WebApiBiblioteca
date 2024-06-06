using Domain.Entities;

namespace WebAPI.Services
{
    public interface IAutorService
    {
        public Task<Response<List<Autor>>> GetAutores();
        public Task<Response<Autor>> Crear(Autor a);
        public Task<Response<Autor>> Actualizar(int pkAutor, Autor a);
        public Task<Response<Autor>> Eliminar(int pkAutor);


    }
}
