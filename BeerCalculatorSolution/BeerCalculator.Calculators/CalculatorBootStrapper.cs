using Common.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using BeerCalculator.Calculators;

namespace BeerCalculators.Calculators
{
    public class CalculatorBootStrapper : BootStrapper
    {
        public CalculatorBootStrapper(IUnityContainer container, IServiceLocator locator) : base(container, locator)
        {
        }

        public override void RegisterServices()
        {
            Container.RegisterType<IIbuCalculator, IbuCalculator>();
            Container.RegisterType<IGravityCalculator, GravityCalculator>();
            Container.RegisterType<IHopUtilizationTable, HopUtilizationTable>();
            Container.RegisterType<IAttenuationCalculator, AttenuationCalculator>();
            Container.RegisterType<IAbvCalculator, AbvCalculator>();
        }
    }
}
