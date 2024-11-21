using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaVenta.DAL.Interfaces;
using SistemaVenta.DAL.DBContext;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Data;
//Clase que implementa la interfaz de DAL

namespace SistemaVenta.DAL.Implementacion
{
    //Hereda de la interfaz, click derecho al error e implementamos la interfaz
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        //Creamos el DbContext
        private readonly DBVENTAContext _dbContext;

        //Creamos el constructor
        public GenericRepository(DBVENTAContext dbContext)
        {
                _dbContext= dbContext;
        }

        //Ordenamos los metodos Conforme la interfaz
        public async Task<TEntity> Obtener(Expression<Func<TEntity, bool>> filtro)
        {
            try
            {
                TEntity entidad = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(filtro);
                return entidad;
            }
            catch
            {
                throw;
            }
        }
        public async Task<TEntity> Crear(TEntity entidad)
        {
            try
            {
                _dbContext.Set<TEntity>().Add(entidad);
                await _dbContext.SaveChangesAsync();
                return entidad;
            }
            catch
            {
                throw;
            }
        }
        public async Task<bool> Editar(TEntity entidad)
        {
            try
            {
                //Se puede poner de la siguiente manera
                //_dbContext.Set<TEntity>().Update(entidad);
                //Pero un codigo más corto sería este
                _dbContext.Update(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Eliminar(TEntity entidad)
        {
            try
            {
                //Se puede poner de la siguiente manera
                //_dbContext.Set<TEntity>().Remove(entidad);
                //Pero un codigo más corto sería este
                _dbContext.Remove(entidad);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
        public async Task<IQueryable<TEntity>> Consultar(Expression<Func<TEntity, bool>> filtro = null)
        {
            //Si el filtro está nulo, enviamos la entidad al contexto
            IQueryable<TEntity> queryEntidad = filtro == null ? _dbContext.Set<TEntity>(): _dbContext.Set<TEntity>().Where(filtro);
            return queryEntidad;
        }     
    }
}
