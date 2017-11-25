using BeerCalculator.Calculators;
using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using BeerCalculators.Calculators;
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

            new CalculatorBootStrapper(container, locator);

            calculator = container.Resolve<IWaterCalculator>();
        }

        [TestMethod()]
        public void HefeweizenWaterMetricsTest()
        {
            WaterInputDTO metrics = new WaterInputDTO();

            metrics.DesiredBatchSize = 5.5m;
            metrics.BoilRate = 1.5m;
            metrics.GrainAbsorbtion = .15m;
            metrics.EquipmentDeadSpace = .19m;
            metrics.TrubLoss = .5m;
            metrics.MashThickness = 2;
            metrics.MashTemperature = 152;
            metrics.InitialGrainTemperature = 75;

            #region Grain init
            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();

            GrainTypeDTO grain;
            grain = new GrainTypeDTO();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;
            grain.Lovibond = 1.62m;


            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);
            grain.Lovibond = 2;

            grain = new GrainTypeDTO();
            grain.Amount = 1;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);
            grain.Lovibond = 2;


            #endregion

            calculator.Calculate(metrics, grains);

            Assert.AreEqual<decimal>(5.5m, calculator.StrikeVolume);
            Assert.AreEqual<int>(160, calculator.StrikeTemperature);
            Assert.AreEqual<decimal>(3.84m, calculator.SpargeVolume);
            Assert.AreEqual<decimal>(10, calculator.WaterRequired);
            Assert.AreEqual<decimal>(7.5m, calculator.BoilVolume);


        }
    }
}
