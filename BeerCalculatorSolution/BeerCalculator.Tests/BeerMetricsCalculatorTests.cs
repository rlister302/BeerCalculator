using BeerCalculator.Calculators;
using BeerCalculators.Calculators;
using Common.DTOs;
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
    public class BeerMetricsCalculatorTests
    {
        static IBeerMetricsCalculator calculator;
        [ClassInitialize()]
        public static void Init(TestContext testContext)
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);

            new CalculatorBootStrapper(container, locator);

            calculator = container.Resolve<IBeerMetricsCalculator>();
        }

        [TestMethod()]
        public void TestRoggenbierMetrics()
        {
            #region Grain init

            GrainTypeDTO grain;
            grain = new GrainTypeDTO();
            grain.Amount = 2.25m;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 76;

            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 2.25m;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 81;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 34;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 34;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 33;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 31;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 7;
            grain.MaximumSugarExtraction = 29;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);
            #endregion
        }
    }
}
