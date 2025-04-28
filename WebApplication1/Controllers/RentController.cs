using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

namespace AutoLand_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentController : ControllerBase
    {
        private AutoLandDbContext ctx;
        private readonly IMapper mapper;
        public RentController(IMapper mapper, AutoLandDbContext ctx)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(ctx.Rents.ToArray()); 
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Rents.Find(Id);

            if (item == null) return NotFound();

            return Ok(item);

        }

        [HttpPost]
        public IActionResult Create(CreateRentModel model)
        {
            ctx.Rents.Add(mapper.Map<Rent>(model));
            ctx.SaveChanges();
       
            return Created(); // 201
        }

        [HttpPut]
        public IActionResult Edit(Rent model)
        {
            ctx.Rents.Update(model);
            ctx.SaveChanges();

            return Ok(); // 200
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Rents.Find(id);

            if (item == null) return NotFound(); // 404

            ctx.Rents.Remove(item);
            ctx.SaveChanges();

            return NoContent(); // 204
        }




    }
}
