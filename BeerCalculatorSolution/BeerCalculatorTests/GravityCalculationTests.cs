using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BeerCalculator.Calculators;
using Common.DTOs;
using System.Collections.Generic;
using Common.Abstract;

namespace BeerCalculatorTests
{
    [TestClass]
    public class GravityCalculationTests
    {
        [TestMethod]
        public void GravityCalculation()
        {
            IGravityCalculator calculator = new GravityCalculator();

            GrainTypeDTO grain = new GrainTypeDTO();

            int expectedEfficiency = 70;

            grain.Amount = 10;
            grain.MaximumSugarExtraction = 37;

            List<GrainTypeDTO> grains = new List<GrainTypeDTO>();
            grains.Add(grain);

            IRecipeMetrics metrics = calculator.Calculate(grains, expectedEfficiency);

            Assert.AreEqual<decimal>(1.047m, metrics.ExpectedOG);
        }
    }
}
