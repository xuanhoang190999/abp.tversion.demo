using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TVersion.Models;
using Volo.Abp.Domain.Entities;

namespace TVersion.Services
{
    public interface IService<T, TKey> where T : MyEntity<TKey>
    {
        /// <summary>
        /// Get entity by identifier
        /// </summary>
        /// <param name="id">Identifier</param>
        /// <returns>Entity</returns>
        T GetById(object id);

        /// <summary>
        /// Insert entity
        /// </summary>
        /// <param name="entity">Entity</param>
        T Insert(T entity);
        T Insert2(T entity);

        /// <summary>
        /// Insert entities
        /// </summary>
        /// <param name="entities">Entities</param>
        IEnumerable<T> Insert(IList<T> entities);
        IEnumerable<T> Insert2(IEnumerable<T> entities);

        /// <summary>
        /// Update entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Update(T entity);

        void Update(IEnumerable<T> entities);

        /// <summary>
        /// Delete entity
        /// </summary>
        /// <param name="entity">Entity</param>
        void Delete(T entity);
        void Delete2(T entity);

        /// <summary>
        /// Delete entities
        /// </summary>
        /// <param name="entities">Entities</param>
        void Delete(IEnumerable<T> entities);
        void Delete2(IEnumerable<T> entities);
        void SudoDelete(IEnumerable<T> entities);

        IList<T> Search(Expression<Func<T, bool>> domain = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            int offSet = 0,
            int limit = int.MaxValue);

        IList<T> SudoSearch(Expression<Func<T, bool>> domain = null,
         Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
         int offSet = 0,
         int limit = int.MaxValue);

        IList<TEntity> ExecuteStoredProcedureList<TEntity>(string commandText, params object[] parameters)
          where TEntity : Entity, new();

        IEnumerable<TElement> SqlQuery<TElement>(string sql, params object[] parameters);
        IEnumerable<TElement> SqlQueryContain<TElement>(string @table_name, string @table_temp, string @list_string, string @type_list, string @select_string, string @field, string @wherefirst_string = null, string @wherelast_string = null);

        int SaveChanges();
    }
}
