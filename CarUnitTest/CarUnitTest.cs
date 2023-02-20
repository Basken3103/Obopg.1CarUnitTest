using Ob_opg._1;

namespace CarUnitTest
{
    [TestClass]
    public class CarUnitTest
    {
        [TestMethod("1")]
        [ExpectedException(typeof(ArgumentNullException))]
       
        public void ValidateModelTest()
        {
            //Arrange
            Car car = new Car();

            //Act
            car.ValidateModel();

            //Assert
            Assert.Fail();

        }

        [TestMethod("2")]
        public void ValidateModelTest2()
        {
            //Arrange
            Car car = new Car() { Id = 1,Licenseplate = "CZ30089"};

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => car.ValidateModel());
        
        }

        [TestMethod("3")]
        public void ValidatePriceTest()
        {
            //Arrange
            Car car = new Car() { Price = 150.000 };

            //Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => car.ValidatePrice());

        }

        [TestMethod("4")]
        public void ValidateLicensePlateTest()
        {
            //Arrange
            Car c3 = new Car();

            //Assert
            Assert.ThrowsException<ArgumentNullException>(() => c3.ValidateLicensePlate());

        }

        [TestMethod("5")]
        public void ValidateLicensePlateTest2()
        {
            //Arrange
            Car c3 = new Car() {Licenseplate = "CZ300890"};

            //Assert
            Assert.ThrowsException<ArgumentException>(() => c3.ValidateLicensePlate());

        }















    }
}