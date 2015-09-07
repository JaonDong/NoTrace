using Abp.Domain.Entities;
using Abp.Domain.Repositories;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;

namespace NoTrace.EntityFramework.EntityFramework.Repositories
{
    public class NoTraceRepositoryBase<TEntity, TPrimaryKey>: EfRepositoryBase<NoTraceDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        public NoTraceRepositoryBase(IDbContextProvider<NoTraceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }

    public class NoTraceRepositoryBase<TEntity> : NoTraceRepositoryBase<TEntity, int>
        where TEntity:class,IEntity<int>
    {
        public NoTraceRepositoryBase(IDbContextProvider<NoTraceDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }
    }
}