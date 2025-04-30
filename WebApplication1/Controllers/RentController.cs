using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using WebApplication1;
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
            var resut = mapper.Map<Rent>(model);
            ctx.Rents.Add(resut);
            ctx.SaveChanges();
          
            return Created(); 
        }

        [HttpPut]
        public IActionResult Edit(Rent model)
        {
            ctx.Rents.Update(model);
            ctx.SaveChanges();

            return Ok(); 
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Rents.Find(id);

            if (item == null) return NotFound();

            ctx.Rents.Remove(item);
            ctx.SaveChanges();

            return NoContent(); 
        }




    }
}
