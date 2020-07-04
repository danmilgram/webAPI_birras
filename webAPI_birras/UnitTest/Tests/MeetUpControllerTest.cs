using Microsoft.VisualStudio.TestTools.UnitTesting;
using webAPI_birras.Controllers.Functions;


namespace webAPI_birras_UnitTest.Tests
{
    [TestClass]
    public class MeetUpControllerTest
    {
        [TestMethod]
        public void CalculateBeers_Test1()
        {
            MeetUpFunctions mtf = new MeetUpFunctions();

            //10 PERSONAS, <20 GRADOS, 0,75 BIRRAS C/U --> REDONDEA PARA ARRIBA, 2 CAJONES 
            Assert.IsTrue(mtf.CalculateBeers(10, 18.2) == 12);
        }

        [TestMethod]
        public void CalculateBeers_Test2()
        {
            MeetUpFunctions mtf = new MeetUpFunctions();

            //1 PERSONAS, <20 GRADOS, 0,75 BIRRAS C/U --> REDONDEA PARA ARRIBA, 1 CAJON 
            Assert.IsTrue(mtf.CalculateBeers(1, 5) == 6);
        }

        [TestMethod]
        public void CalculateBeers_Test3()
        {
            MeetUpFunctions mtf = new MeetUpFunctions();

            //50 PERSONAS, >20 GRADOS <24 GRADOS, 1 BIRRAS C/U --> REDONDEA PARA ARRIBA, 9 CAJONES 
            Assert.IsTrue(mtf.CalculateBeers(50, 22) == 54);
        }

        [TestMethod]
        public void CalculateBeers_Test4()
        {
            MeetUpFunctions mtf = new MeetUpFunctions();

            //3 PERSONAS, 30 GRADOS, 3 BIRRAS C/U --> REDONDEA PARA ARRIBA, 2 CAJONES
            Assert.IsTrue(mtf.CalculateBeers(3, 30) == 12);
        }






    }
}
