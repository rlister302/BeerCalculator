using BeerCalculator.Calculators.Implementation;
using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.Abstract;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Tests
{
    class CalculatorTestBootStrapper : BootStrapper
    {
        public CalculatorTestBootStrapper(IUnityContainer container, IServiceLocator locator) : base(container, locator)
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
