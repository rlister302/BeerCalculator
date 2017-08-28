using BeerCalculator.Calculators;
using BeerCalculator.Common.DTOs;
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
    public class SrmCalculatorTests
    {
        private static ISrmCalculator calculator;

        [ClassInitialize()]
        public static void Init(TestContext testContext)
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);

            new CalculatorBootStrapper(container, locator);

            calculator = container.Resolve<ISrmCalculator>();
        }

        [TestMethod()]
        public void TestRoggenbierSrm()
        {
            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();

            #region Grain init

            GrainTypeDTO grain;
            grain = new GrainTypeDTO();
            grain.Amount = 2.25m;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 76;
            grain.Lovibond = 1.7m;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 2.25m;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 81;
            grain.Lovibond = 10m;
            grains.Add(grain);
            

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 34;
            grain.MaximumExtractionRate = 75;
            grain.Lovibond = 30m;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 34;
            grain.MaximumExtractionRate = 75;
            grain.Lovibond = 70m;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 33;
            grain.MaximumExtractionRate = 75;
            grain.Lovibond = 120m;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 31;
            grain.MaximumExtractionRate = 75;
            grain.Lovibond = 175m;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 7;
            grain.MaximumSugarExtraction = 29;
            grain.MaximumExtractionRate = 75;
            grain.Lovibond = 5m;
            grains.Add(grain);
            #endregion

            decimal batchSize = 5.25m;

            calculator.Calculate(grains, batchSize);

            Assert.AreEqual<decimal>(30.49m, calculator.ExpectedMcu);
            Assert.AreEqual<decimal>(15.55m, calculator.ExpectedSrm);

        }

        [TestMethod()]
        public void TestHefeweizenSrm()
        {
            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();

            #region Grain init

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


            #endregion

            decimal batchSize = 5.5m;

            calculator.Calculate(grains, batchSize);

            Assert.AreEqual<decimal>(3.36m, calculator.ExpectedMcu);
            Assert.AreEqual<decimal>(3.43m, calculator.ExpectedSrm);

        }
    }
}
