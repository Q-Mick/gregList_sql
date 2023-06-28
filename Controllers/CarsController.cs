using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using sharpList.Models;

namespace gregList_sql.Controllers;

[ApiController]
[Route("api/cars")]
public class CarsController : ControllerBase
{
  private readonly CarsService _carsService;

  public CarsController(CarsService carsService)
  {
    _carsService = carsService;
  }
    [HttpGet]
    public ActionResult<List<Car>> GetAllCars()
    {
        try
        {
            List<Car> cars = _carsService.GetAllCars();
            return Ok(cars);
        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
            throw;
        }
    }
      [HttpPost]
  public ActionResult<Car> CreateCar([FromBody] Car carData)
  {
    try
    {
      Car car = _carsService.CreateCar(carData);
      return Ok(car);
    }
    catch (Exception e)
    {
      return BadRequest(e.Message);
    }
  }

}