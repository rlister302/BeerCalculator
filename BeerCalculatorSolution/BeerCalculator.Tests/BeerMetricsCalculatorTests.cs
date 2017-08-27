﻿using BeerCalculator.Calculators;
using BeerCalculator.Calculators.Implementation;
using BeerCalculator.Common.Abstract;
using BeerCalculators.Calculators;
using Common.Abstract;
using Common.DTOs;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
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
            RecipeDTO recipe = new RecipeDTO();

            List<GrainTypeDTO> grains;
            List<HopTypeDTO> hops;
            YeastTypeDTO yeast;
           

            #region Grain init

            GrainTypeDTO grain;
            grain = new GrainTypeDTO();
            grain.Amount = 2.25m;
            grain.MaximumSugarExtraction = 35;
            grain.MaximumExtractionRate = 76;

            grains = new List<GrainTypeDTO>();
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

            #region Hop init
            hops = new List<HopTypeDTO>();
            HopTypeDTO hop = new HopTypeDTO();

            hop.AlphaAcid = 3.5m;
            hop.Amount = 1;
            hop.BoilTime = 60;

            hops.Add(hop);
            #endregion

            #region Yeast init
            yeast = new YeastTypeDTO();
            #endregion

            #region WaterMetrics init

            IWaterMetrics waterMetrics = new WaterMetrics();
            waterMetrics.BoilRate = 1.0m;
            waterMetrics.GrainAbsorbtion = .15m;
            waterMetrics.EquipmentDeadSpace = .19m;
            waterMetrics.TrubLoss = .5m;
            waterMetrics.MashThickness = 2m;
            waterMetrics.MashTemperature = 154;
            waterMetrics.InitialGrainTemperature = 75;


            #endregion


            recipe.Grains = grains;
            recipe.Hops = hops;
            recipe.Yeast = yeast;
            recipe.ExpectedAttenuation = 75;
            recipe.MashEfficiency = 73;
            recipe.BoilVolume = 6.75m;
            recipe.FinalVolume = 5.25m;
            recipe.WaterMetrics = waterMetrics;


            IRecipeMetrics metrics = calculator.Calculate(recipe);

            Assert.AreEqual<decimal>(1.055m, metrics.ExpectedOriginalGravity);
            Assert.AreEqual<decimal>(1.011m, metrics.ExpectedFinalGravity);
            Assert.AreEqual<decimal>(5.78m, metrics.ExpectedAbv);
            Assert.AreEqual<decimal>(42.56m, metrics.ExpectedBoilGravityPoints);
            Assert.AreEqual<int>(12, metrics.ExpectedIbu);
            
        }

        [TestMethod()]
        public void TestHefeweizenMetrics()
        {
            RecipeDTO recipe = new RecipeDTO();

            List<GrainTypeDTO> grains;
            List<HopTypeDTO> hops;
            YeastTypeDTO yeast;

            #region Grain init

            GrainTypeDTO grain;
            grain = new GrainTypeDTO();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;

            grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);

            
            #endregion

            #region Hop init
            hops = new List<HopTypeDTO>();
            HopTypeDTO hop = new HopTypeDTO();

            hop.AlphaAcid = 3.7m;
            hop.Amount = 1;
            hop.BoilTime = 60;

            hops.Add(hop);
            #endregion

            #region Yeast init
            yeast = new YeastTypeDTO();
            #endregion

            #region WaterMetrics init

            IWaterMetrics waterMetrics = new WaterMetrics();
            waterMetrics.BoilRate = 1.5m;
            waterMetrics.GrainAbsorbtion = .15m;
            waterMetrics.EquipmentDeadSpace = .19m;
            waterMetrics.TrubLoss = .5m;
            waterMetrics.MashThickness = 2m;
            waterMetrics.MashTemperature = 152;
            waterMetrics.InitialGrainTemperature = 75;


            #endregion


            recipe.Grains = grains;
            recipe.Hops = hops;
            recipe.Yeast = yeast;
            recipe.ExpectedAttenuation = 76;
            recipe.MashEfficiency = 65;
            recipe.BoilVolume = 7.5m;
            recipe.FinalVolume = 5.5m;
            recipe.WaterMetrics = waterMetrics;

            IRecipeMetrics metrics = calculator.Calculate(recipe);

            Assert.AreEqual<decimal>(1.044m, metrics.ExpectedOriginalGravity);
            Assert.AreEqual<decimal>(1.008m, metrics.ExpectedFinalGravity);
            Assert.AreEqual<decimal>(4.72m, metrics.ExpectedAbv);
            Assert.AreEqual<decimal>(32.07m, metrics.ExpectedBoilGravityPoints);
            Assert.AreEqual<int>(14, metrics.ExpectedIbu);

        }

        [TestMethod()]
        public void JsonSerializationTest()
        {
            #region Init

            RecipeDTO recipe = new RecipeDTO();

            List<GrainTypeDTO> grains;
            List<HopTypeDTO> hops;
            YeastTypeDTO yeast;

            #region Grain init

            GrainTypeDTO grain;
            grain = new GrainTypeDTO();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;

            grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grains.Add(grain);


            #endregion

            #region Hop init
            hops = new List<HopTypeDTO>();
            HopTypeDTO hop = new HopTypeDTO();

            hop.AlphaAcid = 3.7m;
            hop.Amount = 1;
            hop.BoilTime = 60;

            hops.Add(hop);
            #endregion

            #region Yeast init
            yeast = new YeastTypeDTO();
            #endregion

            #region WaterMetrics init

            IWaterMetrics waterMetrics = new WaterMetrics();
            waterMetrics.BoilRate = 1.5m;
            waterMetrics.GrainAbsorbtion = .15m;
            waterMetrics.EquipmentDeadSpace = .19m;
            waterMetrics.TrubLoss = .5m;
            waterMetrics.MashThickness = 2m;
            waterMetrics.MashTemperature = 152;
            waterMetrics.InitialGrainTemperature = 75;


            #endregion


            recipe.Grains = grains;
            recipe.Hops = hops;
            recipe.Yeast = yeast;
            recipe.ExpectedAttenuation = 76;
            recipe.MashEfficiency = 65;
            recipe.BoilVolume = 7.5m;
            recipe.FinalVolume = 5.5m;
            recipe.WaterMetrics = waterMetrics;
            #endregion

            Console.WriteLine(JsonConvert.SerializeObject(recipe));
        }
    }
}
