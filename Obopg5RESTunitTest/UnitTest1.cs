
using Ob_opg._1;
using Obopg4_1_.Repositories;

namespace Obopg5RESTunitTest
{
    [TestClass()]
    public class CarsRepositoryTest
    {
        [TestMethod()]
        public void GetAllTest()
        {
            int expectedCount = 3;

            CarsRepository repos = new CarsRepository();

            List<Car> list = repos.GetAllCars();

            Assert.IsNotNull(list);
            Assert.AreEqual(typeof(List<Car>), list.GetType());
            Assert.AreEqual(expectedCount, list.Count);

            foreach (var car in list)
            {
                int foundIds = list.FindAll(x => x.Id == car.Id).Count;
                if (foundIds > 1)
                {
                    Assert.Fail($"ID: {car.Id} exists {foundIds} times in the list");
                }
            }

        }


        [TestMethod()]
        public void GetCarByIdTest()
        {
            int id = 1;
            int wrongId = 4;
            string model = "Citroen C3";
            double price = 150.000;
            string licenseplate = "CZ30089";

            CarsRepository repos = new CarsRepository();

            Car? foundCar = repos.GetCarById(id);
            Car? notFoundCar = repos.GetCarById(wrongId);

            Assert.IsNotNull(foundCar);
            Assert.AreEqual(id, foundCar.Id);
            Assert.AreEqual(model, foundCar.Model);
            Assert.AreEqual(price, foundCar.Price);
            Assert.AreEqual(licenseplate, foundCar.Licenseplate);

            Assert.IsNull(notFoundCar);
        }













    }
}