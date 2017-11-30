using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.DTOs
{
    public class MessageContainer<T>
    {
        public IEnumerable<string> Messages { get; set; }

        public T Data { get; set; }
    }
}
