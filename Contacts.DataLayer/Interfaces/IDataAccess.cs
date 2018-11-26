using System.Collections.Generic;

namespace Contacts.DataLayer.Interfaces
{
    public interface IDataAccess<TEntity> where TEntity : class
    {
        IEnumerable<TEntity> Get();

        TEntity GetByID(object id);

        void Insert(TEntity entity);

        void Delete(object id);

        void Delete(TEntity entityToDelete);

        void Attach(TEntity entityToUpdate);
    }
}