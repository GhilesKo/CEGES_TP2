using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using CEGES_DataAccess.Data;
using System.Threading.Tasks;
using CEGES_Core.IRepository;

namespace CEGES_DataAccess.Repository
{
    public class RepositoryAsync<T> : IRepositoryAsync<T> where T : class
    {
        // pour accéder à la BD, aux entités
        private readonly CegesDbContext _db;

        // pour faire des changements directs
        internal DbSet<T> dbset;

        public RepositoryAsync(CegesDbContext db)
        {
            _db = db;
            this.dbset = _db.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
        }

        public async Task<T> GetAsync(int id)
        {
            return await dbset.FindAsync(id);
        }

        #region Versions FirstOrDefaultAsync avec paramètres nulls
        public async Task<T> FirstOrDefaultAsync()
        {
            return await FirstOrDefaultAsync(null, null, true);
        }
        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await FirstOrDefaultAsync(filter, null, true);
        }

        public async Task<T> FirstOrDefaultAsync(string includeProperties)
        {
            return await FirstOrDefaultAsync(null, includeProperties, true);
        }

        public async Task<T> FirstOrDefaultAsync(bool isTracking)
        {
            return await FirstOrDefaultAsync(null, null, isTracking);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties)
        {
            return await FirstOrDefaultAsync(filter, includeProperties, true);
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, bool isTracking)
        {
            return await FirstOrDefaultAsync(filter, null, isTracking);
        }

        public async Task<T> FirstOrDefaultAsync(string includeProperties, bool isTracking)
        {
            return await FirstOrDefaultAsync(null, includeProperties, isTracking);
        }
        #endregion

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, string includeProperties, bool isTracking)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // reproduit: _db.Product.Include(u => u.Category).Include(u => u.Size)
                    // mais passé en string
                    query = query.Include(includeProp);
                }
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.FirstOrDefaultAsync();
        }

        #region Versions GetAllAsync avec paramètres nulls
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await GetAllAsync(null, null, null, true);
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter)
        {
            return await GetAllAsync(filter, null, null, true);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string includeProperties)
        {
            return await GetAllAsync(null, null, includeProperties, true);
        }

        public async Task<IEnumerable<T>> GetAllAsync(bool isTracking)
        {
            return await GetAllAsync(null, null, null, isTracking);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, string includeProperties)
        {
            return await GetAllAsync(filter, null, includeProperties, true);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, bool isTracking)
        {
            return await GetAllAsync(filter, null, null, isTracking);
        }

        public async Task<IEnumerable<T>> GetAllAsync(string includeProperties, bool isTracking)
        {
            return await GetAllAsync(null, null, includeProperties, isTracking);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return await GetAllAsync(null, orderBy, null, true);
        }
        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy)
        {
            return await GetAllAsync(filter, orderBy, null, true);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            return await GetAllAsync(null, orderBy, includeProperties, true);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool isTracking)
        {
            return await GetAllAsync(null, orderBy, null, isTracking);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties)
        {
            return await GetAllAsync(filter, orderBy, includeProperties, true);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, bool isTracking)
        {
            return await GetAllAsync(filter, orderBy, null, isTracking);
        }

        public async Task<IEnumerable<T>> GetAllAsync(Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties, bool isTracking)
        {
            return await GetAllAsync(null, orderBy, includeProperties, isTracking);
        }
        #endregion

        public async Task<IEnumerable<T>> GetAllAsync(Expression<Func<T, bool>> filter, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy, string includeProperties, bool isTracking)
        {
            IQueryable<T> query = dbset;
            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (includeProperties != null)
            {
                foreach (var includeProp in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    // reproduit: _db.Product.Include(u => u.Category).Include(u => u.Size)
                    // mais passé en string
                    query = query.Include(includeProp);
                }
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            if (!isTracking)
            {
                query = query.AsNoTracking();
            }

            return await query.ToListAsync();

        }

        public void Remove(T entity)
        {
            dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entity)
        {
            // Supprimer plusieurs lignes en même temps
            dbset.RemoveRange(entity);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}