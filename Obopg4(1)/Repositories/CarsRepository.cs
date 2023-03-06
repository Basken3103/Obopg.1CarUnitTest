using Ob_opg._1;

namespace Obopg4_1_.Repositories
{
    public class CarsRepository
    {
        private  int _nextId;
        private  List<Car> _cars;


        public CarsRepository()
        {
            _nextId = 1;
            _cars = new List<Car>();
            {
                new Car() { Id = _nextId++, Model = "Citroen C3", Licenseplate = "CZ30089", Price = 150.000 };
                new Car() { Id = _nextId++, Model = "Toyota Aygo", Licenseplate = "AB12345", Price = 100.000 };
                new Car() { Id = _nextId++, Model = "Mercedes trash", Licenseplate = "BC23456", Price = 120.000 };
            };

        }

        // GetAll
        public List<Car> GetAllCars()
        {
            return new List<Car>(_cars);
        }


        // GetbyId
        public Car? GetCarById(int id)
        {
            return _cars.Find(c => c.Id == id);
        }


        // Add
        public Car Add(Car newCar)
        {
            newCar.Validate();
            newCar.Id = _nextId++;
            _cars.Add(newCar);
            return newCar;
            
        }

        // Delete
        public Car? Delete(int id)
        {
            Car? foundCar = GetCarById(id);
            if (foundCar == null)
            {
                return null;
            }
            _cars.Remove(foundCar);
            return foundCar;
        }

        // Update
        public Car? Update(int id, Car updates)
        {
            Car? foundCar = GetCarById(id);
            if (foundCar == null)
            {
                return null;
            }
            foundCar.Model = updates.Model;
            foundCar.Licenseplate = updates.Licenseplate;
            foundCar.Price = updates.Price;
            return foundCar;



















        }

    }
}