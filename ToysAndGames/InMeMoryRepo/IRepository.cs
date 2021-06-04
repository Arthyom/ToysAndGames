using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToysAndGames.InMeMoryRepo
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();
        List<TEntity> Query{get;}



        Task<bool> Add( TEntity entity );

        Task<bool> Delete(TEntity entity);

        Task<bool> Update(TEntity entity);

        Task<TEntity> Get_ById(TEntity entity);

        Task<TEntity> Get_ById( int id );



        Task<int> Save();
    }
}
