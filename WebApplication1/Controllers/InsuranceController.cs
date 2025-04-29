using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

namespace AutoLand_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InsuranceController : ControllerBase
    {
        private AutoLandDbContext ctx;
        private readonly IMapper mapper;
        public InsuranceController(IMapper mapper, AutoLandDbContext ctx)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(ctx.Insurances.ToArray()); 
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Insurances.Find(Id);

            if (item == null) return NotFound();

            return Ok(item);

        }

        [HttpPost]
        public IActionResult Create(CreateInsuranceModel model)
        {
            ctx.Insurances.Add(mapper.Map<Insurance>(model));
            ctx.SaveChanges();
            return Created(); 
        }

        [HttpPut]
        public IActionResult Edit(Insurance model)
        {
            ctx.Insurances.Update(model);
            ctx.SaveChanges();
            return Ok(); 
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Insurances.Find(id);

            if (item == null) return NotFound();

            ctx.Insurances.Remove(item);
            ctx.SaveChanges();

            return NoContent(); 
        }
    }
}
