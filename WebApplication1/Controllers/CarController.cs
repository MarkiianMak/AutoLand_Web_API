using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Microsoft.EntityFrameworkCore;

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
           var a = ctx.Cars.Include(c => c.Reviews).ToArray();
            return Ok(a); 
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Cars.Find(Id);
            if (item == null) return NotFound();
            return Ok(item);

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
