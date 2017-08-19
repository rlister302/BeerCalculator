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

            gravityCalculator.Calculate(grains, expectedEfficiency);

            Assert.AreEqual<decimal>(1.047m, gravityCalculator.OriginalGravity);
        }

        [TestMethod()]
        public void TestGravityPoints()
        {
            decimal finalGravityPoints = 61.68m;

            
            decimal boilPoints= ((decimal)finalGravityPoints * .76m);

            Console.Write(decimal.Round(boilPoints, 2));
        }

        [TestMethod()]
        public void TestGravityPointsCalculation()
        {
            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();
            GrainTypeDTO grain;

            grain = new GrainTypeDTO();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 35;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 8;
            grain.MaximumSugarExtraction = 38;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 2;
            grain.MaximumSugarExtraction = 35;
            grains.Add(grain);

            gravityCalculator.Calculate(grains, 75);

            Console.WriteLine(gravityCalculator.TotalGravityPoints);

        }
    }
}
