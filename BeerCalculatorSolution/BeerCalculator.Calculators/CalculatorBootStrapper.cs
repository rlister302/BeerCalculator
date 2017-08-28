﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using BeerCalculator.Calculators;
using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.Interface;

namespace BeerCalculators.Calculators
{
    public class CalculatorBootStrapper : BootStrapper
    {
        public CalculatorBootStrapper(IUnityContainer container, IServiceLocator locator) : base(container, locator)
        {
        }

        public override void RegisterServices()
        {
            Container.RegisterType<IIbuCalculator, LaymanIbuCalculator>();
            Container.RegisterType<IGravityCalculator, GravityCalculator>();
            Container.RegisterType<IHopUtilizationTable, HopUtilizationTable>();
            Container.RegisterType<IAttenuationCalculator, AttenuationCalculator>();
            Container.RegisterType<IAbvCalculator, AbvCalculator>();
            Container.RegisterType<ISrmCalculator, SrmCalculator>();
            Container.RegisterType<IWaterCalculator, WaterCalculator>();

            Container.RegisterType<IBeerMetricsCalculator, BeerMetricsCalculator>();
        }
    }
}
