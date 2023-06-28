using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using sharpList.Models;

namespace gregList_sql.Services;

public class CarsService
{
    private readonly CarsRepository _repo;

      public CarsService(CarsRepository repo)
  {
    _repo = repo;
  }

  internal Car CreateCar(Car carData)
  {
    Car car = _repo.CreateCar(carData);
    return car;
  }

  internal List<Car> GetAllCars()
  {
    List<Car> cars = _repo.GetAllCars();
    return cars;
  }
}
