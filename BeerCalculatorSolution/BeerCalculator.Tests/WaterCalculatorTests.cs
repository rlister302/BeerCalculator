using BeerCalculator.Calculators;
using BeerCalculator.Calculators.Implementation;
using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using BeerCalculators.Calculators;
using BeerCalculators.Calculators.Implementation;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerCalculator.Tests
{
    [TestClass()]
    public class WaterCalculatorTests
    {
        static IWaterCalculator calculator;

        [ClassInitialize()]
        public static void Init(TestContext context)
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);

            new CalculatorTestBootStrapper(container, locator);

            calculator = container.Resolve<IWaterCalculator>();
        }

        [TestMethod()]
        public void HefeweizenWaterMetricsTest()
        {
            IWaterInput input = new WaterInput();

            input.DesiredBatchSize = 5.5m;
            input.BoilRate = 1.5m;
            input.GrainAbsorbtion = .15m;
            input.EquipmentDeadSpace = .19m;
            input.TrubLoss = .5m;
            input.MashThickness = 2;
            input.MashTemperature = 152;
            input.InitialGrainTemperature = 75;

            #region Grain init
            List<IGrain> grains = new List<IGrain>();

            Grain grain;
            grain = new Grain();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;
            grain.Lovibond = 1.62m;


            grains.Add(grain);

            grain = new Grain();
            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);
            grain.Lovibond = 2;

            grain = new Grain();
            grain.Amount = 1;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);
            grain.Lovibond = 2;


            #endregion

            IWaterMetrics metrics = calculator.Calculate(input, grains);

            Assert.AreEqual<decimal>(5.5m, metrics.StrikeVolume);
            Assert.AreEqual<int>(160, metrics.StrikeTemperature);
            Assert.AreEqual<decimal>(3.84m, metrics.SpargeVolume);
            Assert.AreEqual<decimal>(10, metrics.WaterRequired);
            Assert.AreEqual<decimal>(7.5m, metrics.BoilVolume);


        }
    }
}
