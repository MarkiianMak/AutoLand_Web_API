using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1;

namespace AutoLand_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private AutoLandDbContext ctx;
        private readonly IMapper mapper;
        public CarController(IMapper mapper, AutoLandDbContext ctx)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var a = ctx.Cars.ToArray();
            return Ok(a); 
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Cars.Include(i => i.Reviews)
                               .Include(i => i.Rents)
                               .FirstOrDefault(i => i.Id == Id);
            if (item == null) return NotFound();

            //var result = new CarDto
            //{
            //    Id = item.Id,
            //    Brand = item.Brand,
            //    Model = item.Model,
            //    Year = item.Year,
            //    BodyType = item.BodyType,
            //    Mileage = item.Mileage,
            //    FuelType = item.FuelType,
            //    NumberPlate = item.NumberPlate,
            //    Price = item.Price,
            //    Status = item.Status,
            //    Reviews = item.Reviews.Select(r => new ReviewDto

            //    {
            //        Rating = r.Raiting,
            //        Comment = r.Comment
            //    }).ToList()
            //};

            var result = mapper.Map<CarDto>(item);
            return Ok(result);

        }

        [HttpPost]
        public IActionResult Create(CreateCarModel model)
        {
            ctx.Cars.Add(mapper.Map<Car>(model));
            ctx.SaveChanges();
            return Created(); 
        }

        [HttpPut]
        public IActionResult Edit(Car model)
        {
            ctx .Cars.Update(model);
            ctx.SaveChanges();

            return Ok(); 
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Cars.Find(id);

            if (item == null) return NotFound();

            ctx.Cars.Remove(item);
            ctx.SaveChanges();

            return NoContent();
        }

    }
}
