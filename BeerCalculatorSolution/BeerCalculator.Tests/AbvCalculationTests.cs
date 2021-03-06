﻿using BeerCalculator.Calculators;
using BeerCalculator.Calculators.Interface;
using BeerCalculator.Common.Interface;
using BeerCalculators.Calculators;
using BeerCalculators.Calculators.Implementation;
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
    public class AbvCalculationTests
    {
        static IAbvCalculator abvCalculator;

        [ClassInitialize()]
        public static void Init(TestContext testContext)
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);

            new CalculatorTestBootStrapper(container, locator);

            abvCalculator = container.Resolve<IAbvCalculator>();
        }

        [TestMethod()]
        public void HefeweizenAbvTest()
        {
            decimal originalGravity = 1.044m;
            decimal finalGravity = 1.008m;

            decimal abv = abvCalculator.Calculate(originalGravity, finalGravity);

            Assert.AreEqual<decimal>(4.72m, abv);
        }
    }
}
