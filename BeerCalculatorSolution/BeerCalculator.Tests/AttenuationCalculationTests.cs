using BeerCalculator.Calculators;
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
    public class AttenuationCalculationTests
    {
        static IAttenuationCalculator attenuationCalculator;
        [ClassInitialize()]
        public static void Init(TestContext context)
        {
            IUnityContainer container = new UnityContainer();
            IServiceLocator locator = new UnityServiceLocator(container);

            new CalculatorBootStrapper(container, locator);

            attenuationCalculator = container.Resolve<IAttenuationCalculator>();
        }

        [TestMethod()]
        public void TestAttenuationCalculationKolsch()
        {
            int expectedAttenuation = 75;
            decimal originalGravity = 47.45m;

            decimal finalGravity = attenuationCalculator.Calculate(originalGravity, expectedAttenuation);

            Assert.AreEqual<decimal>(1.012m, finalGravity);

        }

        [TestMethod()]
        public void TestAttenuationCalculationRoggenbier()
        {
            int expectedAttenuation = 75;
            decimal originalGravity = 42.56m;

            decimal finalGravity = attenuationCalculator.Calculate(originalGravity, expectedAttenuation);

            Assert.AreEqual<decimal>(1.011m, finalGravity);

        }

        [TestMethod()]
        public void TestAttenuationCalculationHefeweizen()
        {
            int expectedAttenuation = 76;
            decimal originalGravity = 32.07m;

            decimal finalGravity = attenuationCalculator.Calculate(originalGravity, expectedAttenuation);

            Assert.AreEqual<decimal>(1.008m, finalGravity);
        }

        [TestMethod()]
        public void TestAttenuationCalculation3()
        {
            int expectedAttenuation = 75;
            decimal originalGravity = 34.26m;

            decimal finalGravity = attenuationCalculator.Calculate(originalGravity, expectedAttenuation);

            Assert.AreEqual<decimal>(1.009m, finalGravity);
        }


        [TestMethod()]
        public void TestAttenuationCalculation4()
        {
        
        }
    }
}
