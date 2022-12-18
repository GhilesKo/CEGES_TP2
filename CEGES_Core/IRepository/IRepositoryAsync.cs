using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace CEGES_Core.IRepository
{
    // Ce doit être une interface générique <T> (T pour s'adapter au type d'objet classe ) publique
    public interface IRepositoryAsync<T> where T : class
    {
        // Les méthodes devant être implantées dans les repositories

        Task<T> GetAsync(int id);

        /* doit tenir compte que certains retournent des VM avec des filtres (where) et des liaisons
             Exemple: IEnumerable<Product> objList = _db.Product.Include(u => u.Category).Include(u => u.Size);
          Expression<Func> permet le linq avec filter permet le where
          IOrderedQueryable... permet le orderby
          includeProperties permet le lié avec Include
          isTracking, par défaut dans EF Core, utile mais diminue la performance. Pour Retreive seulement, peut être false
        */

        #region Versions GetAllAsync avec paramètres nulls
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter);
        Task<IEnumerable<T>> GetAllAsync(string includeProperties);
        Task<IEnumerable<T>> GetAllAsync(bool isTracking);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, string includeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool isTracking);
        Task<IEnumerable<T>> GetAllAsync(string includeProperties, bool isTracking);
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy);
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool isTracking);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties);
        Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool isTracking);
        Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties, bool isTracking);
        #endregion

        Task<IEnumerable<T>> GetAllAsync(
          Expression<Func<T, bool>> filter = null,
          Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
          string includeProperties = null,
          bool isTracking = true
          );

        // Retourne le 1er seulement
        #region Versions FirstOrDefaultAsync avec paramètres nulls
        Task<T> FirstOrDefaultAsync();
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter);
        Task<T> FirstOrDefaultAsync(string includeProperties);
        Task<T> FirstOrDefaultAsync(bool isTracking);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties);
        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, bool isTracking);
        Task<T> FirstOrDefaultAsync(string includeProperties, bool isTracking);
        #endregion

        Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter = null, string includeProperties = null, bool isTracking = true);

        Task AddAsync(T entity);

        void Remove(T entity);

        void RemoveRange(IEnumerable<T> entity);

        void Save();
    }
}