using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;
using System.Text;

namespace Core.DataAccess.EntityFramework
{ // bu bizim için generic bi yapı sorgu yaparken zaten context ve varlık değişir
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
     where TEntity : class, IEntity, new()
     where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var addedEntity = context.Entry(entity);//gönderilen entityi contexte abone et
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//gönderilen entityi contexte abone et
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())//dipossible pattern yani nesnenin hayatını sonlandırmasını bellekten silinmesini sağlae bu demek
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null)
        {
            using (var context = new TContext())
            {
                return filter == null
                    ? context.Set<TEntity>().ToList()//filtre boşsa hepsini listele
                     : context.Set<TEntity>().Where(filter).ToList();



            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//gönderilen entityi contexte abone et
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}//Bu işlemlerdn sonra artık bütün operasyonlarımız hazır.
