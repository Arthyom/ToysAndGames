using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;
using ToysAndGames.AppContext;

namespace ToysAndGames.InMeMoryRepo
{
    public class In_Memory_Repo<T> : IRepository<T> where T : class
    {
        private readonly AppDbContext app_Db_Context;

        public List<T> Query
        {
            get { return app_Db_Context.Set<T>().ToList();  }
        }

        public In_Memory_Repo(
            AppDbContext app_db_context
        )
        {
            app_Db_Context = app_db_context;
        }
    
        

        public async Task< bool>  Add( T entity )
        {
            app_Db_Context.Add(entity);
            int entries = await Save();
            if ( entries == 1 )
                return true;
            return false;
        }

        public async Task<bool> Delete( T entity )
        {
            app_Db_Context.Remove(entity);
            int entries = await Save();
            if (entries == 1)
                return true;
            return false;
        }

        public async Task<bool> Update(T entity)
        {
            app_Db_Context.Update(entity);
            int entries = await Save();
            if (entries == 1)
                return true;
            return false;
        }

        public async Task<T> Get_ById(T entity)
        {
            var s = await app_Db_Context.FindAsync(typeof(T), entity);
            return (T)s;
        }


        public async Task<int> Save()
        {
            return await app_Db_Context.SaveChangesAsync();
        }

        public List<T> GetAll()
        {
            return Query;
        }

        public async Task<T> Get_ById(int id)
        {
            return await app_Db_Context.FindAsync<T>(id);
        }

        
    }
}
