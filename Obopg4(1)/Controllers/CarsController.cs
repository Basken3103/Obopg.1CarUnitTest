using Microsoft.AspNetCore.Mvc;
using Ob_opg._1;
using Obopg4_1_.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Obopg4_1_.Controllers
{
    [Route("api/[controller]")]
    //URI: api/cars
    [ApiController]
    public class CarsController : ControllerBase
    {
        private CarsRepository _repository;

        public CarsController(CarsRepository repository)
        {
            _repository = repository;
        }


        // GET: api/<CarsController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet]
        public ActionResult<IEnumerable<Car>> Get()
        {
            List<Car> result = _repository.GetAllCars();
            if (result.Count > 0)
            {
                return Ok(result);
            }
            else
            {
                return NoContent();
            }
        }

        // GET api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("{id}")]
        public ActionResult<Car> Get(int id)
        {
            Car? foundCar = _repository.GetCarById(id);
            if (foundCar == null)
            {
                return NotFound();
            }
            return Ok(foundCar);

        }


        // POST api/<CarsController>
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        public ActionResult<Car> Post([FromBody] Car newCar)
        {
            try
            {
                Car createdCar = _repository.Add(newCar);
                return Created("api/cars/" + createdCar.Id, createdCar);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                       ex is ArgumentOutOfRangeException ||
                                       ex is ArgumentException)
            {
                return BadRequest(ex.InnerException);
            }

        }

        // DELETE api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpDelete("{id}")]
        public ActionResult<Car> Delete(int id)
        {
            Car? deletedCar = _repository.Delete(id);
            if (deletedCar == null)
            {
                return NotFound();
            }
            return Ok(deletedCar);

        }




        // PUT api/<CarsController>/5
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpPut("{id}")]
        public ActionResult<Car> Put(int id, [FromBody] Car updates)
        {
            try
            {
                Car? updatedCar = _repository.Update(id, updates);
                if (updatedCar == null)
                {
                    return NotFound();
                }
                return Ok(updatedCar);
            }
            catch (Exception ex) when (ex is ArgumentNullException ||
                                       ex is ArgumentOutOfRangeException ||
                                       ex is ArgumentException)
            {
                return BadRequest(ex.InnerException);
            }



        }


    }
}
