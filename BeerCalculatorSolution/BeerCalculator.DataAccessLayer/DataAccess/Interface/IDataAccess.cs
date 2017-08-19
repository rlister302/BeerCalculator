using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Abstract;
using Common.DTOs;

namespace DataAccessLayer.DataAccess.Interface
{
    public interface IDataAccess<T> where T : ModelBase
    {
        bool Create(T create);
        IEnumerable<T> Get();
        T Get(T details);
        bool Update(T update);
        bool Delete(int delete);
    }
}
