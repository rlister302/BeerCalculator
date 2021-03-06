﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using BeerCalculator.Common.Interface;

namespace BeerCalculator.Common.Abstract
{
    public abstract class BootStrapper : IBootStrapper
    {
        public IUnityContainer Container { get; set; }

        public IServiceLocator Locator { get; set; }

        public BootStrapper(IUnityContainer container, IServiceLocator locator)
        {
            Container = container;
            Locator = locator;
            RegisterServices();
        }

        public abstract void RegisterServices();
        
    }
}
