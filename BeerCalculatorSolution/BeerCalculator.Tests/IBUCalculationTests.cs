﻿using BeerCalculator.Calculators;
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

namespace BeerCalculatorTests
{
    [TestClass()]
    public class IBUCalculationTests
    {
        static IIbuCalculator ibuCalculator;

        [ClassInitialize()]
        public static void Init(TestContext context)
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);

            new CalculatorBootStrapper(container, locator);

            ibuCalculator = container.Resolve<IIbuCalculator>();

        }

        [TestMethod()]
        public void TestDecimalToDoubleConversion()
        {
            decimal decimalValue = 0.055m;

            double doubleValue = (double)decimalValue;

            Console.WriteLine("{0}", doubleValue);
        }

        [TestMethod()]
        public void TestAlphaAcidUnits()
        {
            HopTypeDTO hop = new HopTypeDTO();
            List<HopTypeDTO> hops = new List<HopTypeDTO>();
            decimal og = 1.047m;

            hop.AlphaAcid = 6.4m;
            hop.Amount = 1.5m;
            hop.BoilTime = 60;

            hops.Add(hop);



            ibuCalculator.Calculate(hops, og);

            Assert.AreEqual<decimal>(9.6m, ibuCalculator.TotalAlphaAcidUnits);
        }

        [TestMethod()]
        public void TestAlphaAcidUnitsWithMultipleHops()
        {
            HopTypeDTO hop = new HopTypeDTO();
            List<HopTypeDTO> hops = new List<HopTypeDTO>();
            decimal og = 1.080m;

            hop.AlphaAcid = 6.4m;
            hop.Amount = 1.5m;
            hop.BoilTime = 60;

            hops.Add(hop);

            hop = new HopTypeDTO();
            hop.AlphaAcid = 4.6m;
            hop.Amount = 1.0m;
            hop.BoilTime = 15;
            hops.Add(hop);

            ibuCalculator.Calculate(hops, og);

            Assert.AreEqual<decimal>(14.2m, ibuCalculator.TotalAlphaAcidUnits);
        }

        [TestMethod()]
        public void TestIbuCalculation()
        {
            HopTypeDTO hop = new HopTypeDTO();
            List<HopTypeDTO> hops = new List<HopTypeDTO>();
            decimal og = 1.080m;

            hop.AlphaAcid = 6.4m;
            hop.Amount = 1.5m;
            hop.BoilTime = 60;

            hops.Add(hop);

            hop = new HopTypeDTO();
            hop.AlphaAcid = 4.6m;
            hop.Amount = 1.0m;
            hop.BoilTime = 15;
            hops.Add(hop);

            int ibu = ibuCalculator.Calculate(hops, og);

            Console.WriteLine("Total IBU {0}", ibu);
        }

        [TestMethod()]
        public void TestRoundingWithModulo()
        {
            decimal gravity = 1.047m;

            int wholeNumberGravity = (int)(gravity * 1000);

            Assert.AreEqual<int>(1047, wholeNumberGravity);

            int remainder = wholeNumberGravity % 10;

            Assert.AreEqual<int>(7, remainder);

            int amountToAddToGravity = 10 - remainder;

            wholeNumberGravity += amountToAddToGravity;

            Assert.AreEqual<int>(1050, wholeNumberGravity);

            double temp = (double)wholeNumberGravity / 1000;

            gravity = decimal.Round((decimal)temp, 3);

           

            Console.WriteLine(gravity.ToString("N3"));
            

       

            //Assert.AreEqual<decimal>(1.050m, gravity);
        }

        [TestMethod()]
        public void TestDecimalToStringConversion()
        {
            decimal x = 1.045m;

            string y = x.ToString();

            Assert.AreEqual<string>("1.045", y);
        }

        [TestMethod()]
        public void TestDecimalToStringConversionWithEvenGravity()
        {
            decimal x = 1.040m;

            string y = x.ToString();

            Assert.AreEqual<string>("1.040", y);
        }

    }
}