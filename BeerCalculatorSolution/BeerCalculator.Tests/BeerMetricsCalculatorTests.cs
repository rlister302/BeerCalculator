using BeerCalculator.Calculators;
using BeerCalculator.Common.Abstract;
using BeerCalculator.Common.DTOs;
using BeerCalculator.Common.Implementation;
using BeerCalculator.Common.Interface;
using BeerCalculators.Calculators;
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
            RecipeInputDTO recipe = new RecipeInputDTO();
            recipe.WaterInput = new WaterInputDTO();

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

            WaterInputDTO waterInput = new WaterInputDTO();
            waterInput.BoilRate = 1.0m;
            waterInput.GrainAbsorbtion = .15m;
            waterInput.EquipmentDeadSpace = .19m;
            waterInput.TrubLoss = .5m;
            waterInput.MashThickness = 2m;
            waterInput.MashTemperature = 154;
            waterInput.InitialGrainTemperature = 75;


            #endregion


            recipe.Grains = grains;
            recipe.Hops = hops;
            recipe.Yeast = yeast;
            recipe.ExpectedAttenuation = 75;
            recipe.MashEfficiency = 73;
            waterInput.DesiredBatchSize = 5.25m;
            recipe.WaterInput = waterInput;


            RecipeMetricsDTO metrics = calculator.Calculate(recipe);

            Assert.AreEqual<decimal>(1.055m, metrics.ExpectedOriginalGravity);
            Assert.AreEqual<decimal>(1.011m, metrics.ExpectedFinalGravity);
            Assert.AreEqual<decimal>(5.78m, metrics.ExpectedAbv);
            Assert.AreEqual<decimal>(42.56m, metrics.ExpectedBoilGravityPoints);
            Assert.AreEqual<int>(12, metrics.ExpectedIbu);
            
        }

        [TestMethod()]
        public void TestHefeweizenMetrics()
        {
            RecipeInputDTO recipe = new RecipeInputDTO();
            recipe.ExpectedAttenuation = 76;

            List<GrainTypeDTO> grains;
            List<HopTypeDTO> hops;
            YeastTypeDTO yeast;

            #region Grain init

            GrainTypeDTO grain;
            grain = new GrainTypeDTO();
            grain.Amount = 4;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 80;
            grain.Lovibond = 1.62m;

            grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 6;
            grain.MaximumSugarExtraction = 37;
            grain.MaximumExtractionRate = 79;
            grain.Lovibond = 2.0m;
            grains.Add(grain);

            grain = new GrainTypeDTO();
            grain.Amount = 1;
            grain.MaximumSugarExtraction = 0;
            grain.MaximumExtractionRate = 0;
            grain.Lovibond = 0m;
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

            WaterInputDTO waterInput = new WaterInputDTO();
            waterInput.BoilRate = 1.5m;
            waterInput.GrainAbsorbtion = .15m;
            waterInput.EquipmentDeadSpace = .19m;
            waterInput.TrubLoss = .5m;
            waterInput.MashThickness = 2m;
            waterInput.MashTemperature = 152;
            waterInput.InitialGrainTemperature = 75;
            waterInput.DesiredBatchSize = 5.5m;


            #endregion


            recipe.Grains = grains;
            recipe.Hops = hops;
            recipe.Yeast = yeast;
            recipe.MashEfficiency = 65;
            recipe.WaterInput = waterInput;

            RecipeMetricsDTO metrics = calculator.Calculate(recipe);

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

            WaterInputDTO waterInput = new WaterInputDTO();
            waterInput.BoilRate = 1.5m;
            waterInput.GrainAbsorbtion = .15m;
            waterInput.EquipmentDeadSpace = .19m;
            waterInput.TrubLoss = .5m;
            waterInput.MashThickness = 2m;
            waterInput.MashTemperature = 152;
            waterInput.InitialGrainTemperature = 75;


            #endregion


            recipe.Grains = grains;
            recipe.Hops = hops;
            recipe.Yeast = yeast;
            recipe.ExpectedAttenuation = 76;
            recipe.MashEfficiency = 65;
            recipe.BoilVolume = 7.5m;
            recipe.FinalVolume = 5.5m;
            recipe.WaterInput = waterInput;
            #endregion

            Console.WriteLine(JsonConvert.SerializeObject(recipe));
        }
    }
}
