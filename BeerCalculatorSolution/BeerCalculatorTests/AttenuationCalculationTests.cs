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
        public void TestAttenuationMethod()
        {
            int expectedAttenuation = 75;
            decimal originalGravity = 1.047m;
            double attenuationRatio = (double)expectedAttenuation / 100;

            int wholeNumberGravity = (int)(originalGravity * 1000);

            int ratio = (int)(wholeNumberGravity * attenuationRatio);

            //1047 - 785
            // 35
            // 12
        }

        [TestMethod()]
        public void TestAttenuationCalculation()
        {
 
        }

        [TestMethod()]
        public void TestAttenuationCalculation2()
        {
            int expectedAttenuation = 75;
            decimal originalGravity = 47.45m;

            decimal finalGravity = attenuationCalculator.Calculate(originalGravity, expectedAttenuation);

            Assert.AreEqual<decimal>(1.012m, finalGravity);
        }

        [TestMethod()]
        public void TestAttenuationCalculation3()
        {
        
        }



        [TestMethod()]
        public void TestAttenuationModuloMethodBelow1100()
        {
            decimal og = 1.047m;
            double expectedAttenuationRate = .75;

             

            int wholeNumberGravity = (int)(og * 1000);

            int remainder = wholeNumberGravity % 1000;

            int expectedAttenuation = (int)(remainder * expectedAttenuationRate);

            Console.WriteLine("Expected Attenuation {0}", expectedAttenuation);

            int finalGravity = remainder - expectedAttenuation;

            Console.WriteLine("Final gravity {0}", finalGravity);

            int attenuation = wholeNumberGravity - remainder;

            string x = string.Format("1.0{0}", finalGravity);

            decimal converted = 1.000m + (decimal)(finalGravity / 1000.0);

            Console.WriteLine("Converted is {0}", converted);

            Console.WriteLine("String gravity {0}", x);

            decimal y = decimal.Parse(x);

            Console.WriteLine("Converted to decimal {0}", y);


            Console.WriteLine("Remainder is {0}", remainder);

            Console.WriteLine("Expected attenuation is {0}", attenuation);

            double decimalFinalGravity = (wholeNumberGravity - attenuation) / 1000.0;

            Console.WriteLine("Final gravity {0}", decimalFinalGravity);
        }

        [TestMethod()]
        public void TestAttenuationModuloMethodAbove1100()
        {
            decimal og = 1.120m;

            int wholeNumberGravity = (int)(og * 1000);

            int remainder = wholeNumberGravity % 1000;

            Console.WriteLine("Remainder is {0}", remainder);
        }
    }
}
