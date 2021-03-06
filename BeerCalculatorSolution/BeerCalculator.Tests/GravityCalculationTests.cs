﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerCalculator.Calculators;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Microsoft.Practices.ServiceLocation;
using BeerCalculators.Calculators;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Interface;
using BeerCalculator.Calculators.Interface;
using BeerCalculator.Calculators.Implementation;
using BeerCalculators.Calculators.Implementation;
using BeerCalculator.Tests;

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

            new CalculatorTestBootStrapper(container, locator);

            gravityCalculator = container.Resolve<IGravityCalculator>();

        }

        [TestCleanup()]
        public void Clean()
        {
            gravityCalculator.BoilGravityPoints = decimal.Zero;
            gravityCalculator.OriginalGravity = decimal.Zero;
        }

        [TestMethod]
        public void OriginalGravityCalculationHefeweizen()
        {

            Grain grain = new Grain();

            int expectedEfficiency = 65;

            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;

            List<IGrain> grains = new List<IGrain>();
            grains.Add(grain);

            grain = new Grain();
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
            // TODO: This test passed before refactoring and failed afterwards.
            // Calculation looks correct as it is now, but I need to find out why it passed in the first place. 
            IGrain grain = new Grain();

            int expectedEfficiency = 65;

            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;

            List<IGrain> grains = new List<IGrain>();
            grains.Add(grain);

            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);

            gravityCalculator.Calculate(grains, expectedEfficiency, 7.5m);

            Assert.AreEqual<decimal>(38.48m, gravityCalculator.BoilGravityPoints);
        }

        [TestMethod]
        public void GravityCalculationGrapefruitIPA()
        { 

            int expectedEfficiency = 60;
            Grain grain = new Grain();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 76;

            List<IGrain> grains = new List<IGrain>();
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = 8;
            grain.MaximumSugarExtraction = 38;
            grain.MaximumExtractionRate = 81;
            grains.Add(grain);

            grain = new Grain();
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

            Grain grain = new Grain();

            int expectedEfficiency = 73;

            grain.Amount = 2.25m;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 76;

            List<IGrain> grains = new List<IGrain>();
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = 2.25m;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 81;
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 34;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 34;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 33;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = .25m;
            grain.MaximumSugarExtraction = 31;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = 7;
            grain.MaximumSugarExtraction = 29;
            grain.MaximumExtractionRate = 75;
            grains.Add(grain);

           

            gravityCalculator.Calculate(grains, expectedEfficiency, 6.75m, 5.25m);

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
            List<IGrain> grains = new List<IGrain>();
            Grain grain;

            grain = new Grain();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 35;
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = 8;
            grain.MaximumSugarExtraction = 38;
            grains.Add(grain);

            grain = new Grain();
            grain.Amount = 2;
            grain.MaximumSugarExtraction = 35;
            grains.Add(grain);

            gravityCalculator.Calculate(grains, 75);

            Console.WriteLine(gravityCalculator.BoilGravityPoints);

        }
    }
}
