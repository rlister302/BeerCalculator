using BeerCalculator.Common.Communication;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BeerCalculator.WebApplication.BootStrapper
{
    public class WebAppBootStrapper : BeerCalculator.Common.Abstract.BootStrapper
    {
        public WebAppBootStrapper(IUnityContainer container, IServiceLocator locator) : base(container, locator)
        {

        }

        public override void RegisterServices()
        {
            Container.RegisterType<IRequestManager, RequestManager>();
        }
    }
}