using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToysAndGames.Models;

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

        Task<List<Product>> Serach_match(string param);

        Task<int> Save();
    }
}
