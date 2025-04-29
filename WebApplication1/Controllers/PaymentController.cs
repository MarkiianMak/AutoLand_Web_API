using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;

namespace AutoLand_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private AutoLandDbContext ctx;
        private readonly IMapper mapper;
        public PaymentController(IMapper mapper, AutoLandDbContext ctx)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(ctx.Payments.ToArray()); 
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Payments.Find(Id);

            if (item == null) return NotFound();

            return Ok(item);

        }

        [HttpPost]
        public IActionResult Create(CreatePaymentModel model)
        {
            ctx.Payments.Add(mapper.Map<Payment>(model));
            ctx.SaveChanges();
            return Created(); 
        }

        [HttpPut]
        public IActionResult Edit(Car model)
        {
            ctx.Cars.Update(model);
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
