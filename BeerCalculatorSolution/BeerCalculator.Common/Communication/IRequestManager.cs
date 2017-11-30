using BeerCalculator.Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Communication
{
    public interface IRequestManager
    {
        Task<object> Create(ModelBase create, Type deserializeTo);

        Task<object> Delete(ModelBase delete, Type deserializeTo);

        Task<object> GetAll(ModelBase retreive, Type deserializeTo);

        Task<object> Get(ModelBase retreive, Type deserializeTo);

        Task<object> Update(ModelBase update, Type deserializeTo);
    }
}
