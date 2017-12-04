using BeerCalculator.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.DataAccessLayer.DataAccess.Interface
{
    public interface IDataAccess<TDTO, TEntity> where TDTO : ModelBase
                                                    where TEntity : class
    {
        bool Create(TDTO create);
        IEnumerable<TDTO> Get();
        TDTO Get(int details);
        bool Update(TDTO update);
        bool Delete(int delete);
    }
}
