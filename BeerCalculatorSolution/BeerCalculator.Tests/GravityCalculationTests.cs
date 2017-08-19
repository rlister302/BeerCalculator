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
        public void OriginalGravityCalculationHefeweizen()
        {

            GrainTypeDTO grain = new GrainTypeDTO();

            int expectedEfficiency = 65;

            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;

            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);

            gravityCalculator.Calculate(grains, expectedEfficiency);

            Assert.AreEqual<decimal>(1.044m, gravityCalculator.OriginalGravity);
        }

        [TestMethod]
        public void BoilGravityCalculationHefeweizen()
        {

            GrainTypeDTO grain = new GrainTypeDTO();

            int expectedEfficiency = 65;

            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;

            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);

            gravityCalculator.Calculate(grains, expectedEfficiency, 7.5);

            Assert.AreEqual<decimal>(32.07m, gravityCalculator.BoilGravityPoints);
        }

        [TestMethod]
        public void GravityCalculationGrapefruitIPA()
        {

            GrainTypeDTO grain = new GrainTypeDTO();

            int expectedEfficiency = 60;

            grain.Amount = 4;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 76;

            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 8;
            grain.MaximumSugarExtraction = 38;
            grain.MaximumExtractionRate = 81;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 2;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            gravityCalculator.Calculate(grains, expectedEfficiency);

            Assert.AreEqual<decimal>(1.056m, gravityCalculator.OriginalGravity);
        }

        [TestMethod]
        public void BoilGravityCalculationRoggenbier()
        {

            GrainTypeDTO grain = new GrainTypeDTO();

            int expectedEfficiency = 73;

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

           

            gravityCalculator.Calculate(grains, expectedEfficiency, 6.75, 5.25);

            Assert.AreEqual<decimal>(1.055m, gravityCalculator.OriginalGravity);
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

            Console.WriteLine(gravityCalculator.BoilGravityPoints);

        }
    }
}
