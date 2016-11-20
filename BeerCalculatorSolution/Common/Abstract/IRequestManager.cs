using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Abstract
{
    public interface IRequestManager<T> where T: ModelBase
    {
        Task<T> Retreive(T retreive);
        Task<List<T>> RetreiveAll(T retreive);
        Task<bool> Create(T create);
        Task<bool> Update(T update);
        Task<bool> Delete(T delete);
    }
}
