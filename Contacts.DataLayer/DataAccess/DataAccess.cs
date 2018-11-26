using Contacts.DataLayer.Interfaces;  
using System.Collections.Generic;  
using System.Data.Entity;  
using System.Linq;
using Contacts.DataLayer.Entity;
  
namespace Contacts.DataLayer.DataAccess
{
    public class DataAccess<TEntity> : IDataAccess<TEntity> where TEntity : class
    {
        /// <summary>  
        /// The context  
        /// </summary>  
        internal ContactsModel context;

        /// <summary>  
        /// The database set  
        /// </summary>  
        internal DbSet<TEntity> dbSet;

        /// <summary>  
        /// Initializes the new instance of MyModel Model  
        /// </summary>  
        /// <param name="context">context object</param>  
        public DataAccess(ContactsModel context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public DataAccess()
        {
        }

        /// <summary>  
        /// Gets all data  
        /// </summary>  
        /// <returns>collection of specified class.</returns>  
        public virtual IEnumerable<TEntity> Get()
        {
            IQueryable<TEntity> query = this.dbSet;
            return query.ToList();
        }

        /// <summary>  
        /// Gets the by identifier.  
        /// </summary>  
        /// <param name ="id"> The identifier.</param>  
        /// <returns> object </returns>  
        public virtual TEntity GetByID(object id)
        {
            return this.dbSet.Find(id);
        }

        /// <summary>  
        /// Insert data  
        /// </summary>  
        /// <param name="entity">object for insertion.</param>  
        public virtual void Insert(TEntity entity)
        {
            this.dbSet.Add(entity);
        }

        /// <summary>  
        ///  Delete data by id  
        /// </summary>  
        /// <param name="id">id</param>  
        public virtual void Delete(object id)
        {
            TEntity entityToDelete = this.dbSet.Find(id);
            this.Delete(entityToDelete);
        }

        /// <summary>  
        /// Delete data  
        /// </summary>  
        /// <param name ="entityToDelete">entity To Delete.</param>  
        public virtual void Delete(TEntity entityToDelete)
        {
            if (this.context.Entry(entityToDelete).State == System.Data.Entity.EntityState.Detached)
            {
                this.dbSet.Attach(entityToDelete);
            }

            this.dbSet.Remove(entityToDelete);
        }

        /// <summary>  
        /// Attach data.  
        /// </summary>  
        /// <param name="entityToUpdate">entity To Update.</param>  
        public virtual void Attach(TEntity entityToUpdate)
        {
            this.dbSet.Attach(entityToUpdate);
            this.context.Entry(entityToUpdate).State = System.Data.Entity.EntityState.Modified;
        }
    }
}