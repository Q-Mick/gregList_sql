using sharpList.Models;

namespace gregList_sql.Repositories;

public class CarsRepository
{
  private readonly IDbConnection _db;

  public CarsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Car CreateCar(Car carData)
  {
    string sql = @"
    INSERT INTO cars
    (@make, @model, @year, @price, @color, @description);
    SELECT * FROM cars WHERE id = LAST_INSERT_ID();
    ";
    Car car = _db.Query<Car>(sql, carData).FirstOrDefault();
    return car;
  }

  internal List<Car> GetAllCars()
  {
    string sql = "SELECT * FROM cars ORDER BY createdAt DESC;";
    List<Car> cars = _db.Query<Car>(sql).ToList();
    return cars;
  }
}