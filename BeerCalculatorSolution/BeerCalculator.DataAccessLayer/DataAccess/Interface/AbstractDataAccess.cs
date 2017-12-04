using BeerCalculator.Common.Abstract;
using DataAccessLayer.DataAccess.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.DataAccessLayer.DataAccess.Interface
{
    public abstract class AbstractDataAccess<TDTO, TEntity> : IDataAccess<TDTO, TEntity> where TDTO : ModelBase where TEntity : class
    {

        protected abstract TEntity ConvertDTOToEntity(TDTO dto);

        protected abstract TDTO ConvertEntityToDTO(TEntity entity);

        protected abstract void SetEntityProperties(TDTO dto, TEntity entity);

        public virtual bool Create(TDTO create)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();
                var entity = ConvertDTOToEntity(create);
                dbSet.Add(entity);
                context.SaveChanges();
                status = true;
            }

            return status;
        }

        public virtual bool Delete(int delete)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();
                var entity = dbSet.Find(delete);
                dbSet.Remove(entity);
                context.SaveChanges();
                status = true;
            }

            return status;
        }

        public virtual IEnumerable<TDTO> Get()
        {
            List<TDTO> dtosToReturn = new List<TDTO>();

            using (var context = new BeerCalculatorEntities())
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();
                foreach (var grainEntity in dbSet)
                {
                    dtosToReturn.Add(ConvertEntityToDTO(grainEntity));
                }
            }

            return dtosToReturn;
        }

        public virtual TDTO Get(int details)
        {
            TDTO dto = null;

            using (var context = new BeerCalculatorEntities())
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();
                TEntity entity = dbSet.Find(details);

                if (entity != null)
                {
                    dto = ConvertEntityToDTO(entity);
                }
            }

            return dto;
        }

        public virtual bool Update(TDTO update)
        {
            bool status = false;

            using (var context = new BeerCalculatorEntities())
            {
                DbSet<TEntity> dbSet = context.Set<TEntity>();
                var entity = dbSet.Find(update.GetPrimaryKeyValue());

                if (entity != null)
                {
                    SetEntityProperties(update, entity);
                    context.SaveChanges();
                    status = true;
                }
            }

            return status;
        }
    }
}
