using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace TestIdentity.Domain
{
    public class MyRepository<TDbContext, TEntity, TPrimaryKey> 
        where TDbContext : DbContext where TEntity : Entity<TPrimaryKey>
    {
        /// <summary>
        /// Gets EF DbContext object.
        /// 
        /// </summary>
        protected  TDbContext Context { get; set; }


        /// <summary>
        /// Gets DbSet for given entity.
        /// 
        /// </summary>
        protected virtual DbSet<TEntity> Table
        {
            get
            {
                return this.Context.Set<TEntity>();
            }
        }

        /// <summary>
        /// Constructor
        /// 
        /// </summary>
        /// <param name="dbContextd"/>
        public MyRepository(TDbContext dbContextd)
        {
            this.Context = dbContextd;
        }

        public  IQueryable<TEntity> GetAll()
        {
            return (IQueryable<TEntity>)this.Table;
        }

        public  async Task<List<TEntity>> GetAllListAsync()
        {
            return await QueryableExtensions.ToListAsync<TEntity>(this.GetAll());
        }

        public  async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await QueryableExtensions.ToListAsync<TEntity>(Queryable.Where<TEntity>(this.GetAll(), predicate));
        }

        public  async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await QueryableExtensions.SingleAsync<TEntity>(this.GetAll(), predicate);
        }

        public  async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id)
        {
            return await QueryableExtensions.FirstOrDefaultAsync<TEntity>(this.GetAll(), CreateEqualityExpressionForId(id));
        }

        public  async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await QueryableExtensions.FirstOrDefaultAsync<TEntity>(this.GetAll(), predicate);
        }

        public  TEntity Insert(TEntity entity)
        {
            return this.Table.Add(entity);
        }

        public  Task<TEntity> InsertAsync(TEntity entity)
        {
            var entityResult= Task.FromResult<TEntity>(this.Table.Add(entity));
            this.Context.SaveChanges();
            return entityResult;
        }

        public  TPrimaryKey InsertAndGetId(TEntity entity)
        {
            entity = this.Insert(entity);
            if (entity.IsTransient())
                this.Context.SaveChanges();
            return entity.Id;
        }

        public  async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity)
        {
            entity = await this.InsertAsync(entity);
            if (entity.IsTransient())
            {
                int num = await this.Context.SaveChangesAsync();
            }
            return entity.Id;
        }

        public  TPrimaryKey InsertOrUpdateAndGetId(TEntity entity)
        {
            entity = this.InsertOrUpdate(entity);
            if (entity.IsTransient())
                this.Context.SaveChanges();
            return entity.Id;
        }

        public  async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity)
        {
            entity = await this.InsertOrUpdateAsync(entity);
            if (entity.IsTransient())
            {
                int num = await this.Context.SaveChangesAsync();
            }
            return entity.Id;
        }

        public  TEntity Update(TEntity entity)
        {
            this.AttachIfNot(entity);
            this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
            return entity;
        }

        public  Task<TEntity> UpdateAsync(TEntity entity)
        {
            this.AttachIfNot(entity);
            this.Context.Entry<TEntity>(entity).State = EntityState.Modified;
            return Task.FromResult<TEntity>(entity);
        }

        public  void Delete(TEntity entity)
        {
            this.AttachIfNot(entity);
            this.Table.Remove(entity);
        }

        public async  Task DeleteAsync(TEntity entity)
        {
            this.AttachIfNot(entity);
            this.Delete(entity);
        }

        public  void Delete(TPrimaryKey id)
        {
            TEntity entity = Enumerable.FirstOrDefault<TEntity>((IEnumerable<TEntity>)this.Table.Local, (Func<TEntity, bool>)(ent => EqualityComparer<TPrimaryKey>.Default.Equals(ent.Id, id)));
            if ((object)entity == null)
            {
                entity = this.FirstOrDefault(id);
                if ((object)entity == null)
                    return;
            }
            this.Delete(entity);
        }

        public  async Task<int> CountAsync()
        {
            return await QueryableExtensions.CountAsync<TEntity>(this.GetAll());
        }

        public  async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await QueryableExtensions.CountAsync<TEntity>(Queryable.Where<TEntity>(this.GetAll(), predicate));
        }

        public  async Task<long> LongCountAsync()
        {
            return await QueryableExtensions.LongCountAsync<TEntity>(this.GetAll());
        }

        public  async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await QueryableExtensions.LongCountAsync<TEntity>(Queryable.Where<TEntity>(this.GetAll(), predicate));
        }

        protected virtual void AttachIfNot(TEntity entity)
        {
            if (this.Table.Local.Contains(entity))
                return;
            this.Table.Attach(entity);
        }
        public virtual TEntity InsertOrUpdate(TEntity entity)
        {
            return EqualityComparer<TPrimaryKey>.Default.Equals(entity.Id, default(TPrimaryKey))
                ? Insert(entity)
                : Update(entity);
        }

        public virtual async Task<TEntity> InsertOrUpdateAsync(TEntity entity)
        {
            return EqualityComparer<TPrimaryKey>.Default.Equals(entity.Id, default(TPrimaryKey))
                ? await InsertAsync(entity)
                : await UpdateAsync(entity);
        }
        public virtual TEntity FirstOrDefault(TPrimaryKey id)
        {
            return GetAll().FirstOrDefault(CreateEqualityExpressionForId(id));
        }
        public virtual TEntity FirstOrDefault(Expression<Func<TEntity, bool>> predicate)
        {
            return GetAll().FirstOrDefault(predicate);
        }

        protected static Expression<Func<TEntity, bool>> CreateEqualityExpressionForId(TPrimaryKey id)
        {
            var lambdaParam = Expression.Parameter(typeof(TEntity));

            var lambdaBody = Expression.Equal(
                Expression.PropertyOrField(lambdaParam, "Id"),
                Expression.Constant(id, typeof(TPrimaryKey))
                );

            return Expression.Lambda<Func<TEntity, bool>>(lambdaBody, lambdaParam);
        }
    }
}