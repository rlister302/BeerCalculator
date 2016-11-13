using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace Models.Communication
{
    public interface IRequestManager<T>
    {
        Task<T> Retreive(int id);
        Task<T> Retreive();
        Task<T> Create(T create);
        Task<T> Update(T update);
        Task<T> Delete(int id);
    }
}
