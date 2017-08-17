using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerCalculator.Calculators;
using Common.DTOs;
using System.Collections.Generic;
using Common.Abstract;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculators.Calculators;

namespace BeerCalculatorTests
{
    [TestClass]
    public class GravityCalculationTests
    {
        static IGravityCalculator gravityCalculator;

        [ClassInitialize()]
        public static void Init(TestContext context)
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);

            new CalculatorBootStrapper(container, locator);

            gravityCalculator = container.Resolve<IGravityCalculator>();

        }

        [TestMethod]
        public void GravityCalculation()
        {

            GrainTypeDTO grain = new GrainTypeDTO();

            int expectedEfficiency = 70;

            grain.Amount = 10;
            grain.MaximumSugarExtraction = 37;

            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            decimal expectedOG = gravityCalculator.Calculate(grains, expectedEfficiency);

            Assert.AreEqual<decimal>(1.047m, expectedOG);
        }
    }
}
