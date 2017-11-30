using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Common.Interface
{
    public interface IBootStrapper
    { 
        IUnityContainer Container { get; set; }

        IServiceLocator Locator { get; set; }

        void RegisterServices();
    }
}
