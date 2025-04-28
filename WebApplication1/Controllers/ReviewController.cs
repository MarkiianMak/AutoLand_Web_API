using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using System.Diagnostics.Eventing.Reader;

namespace AutoLand_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private AutoLandDbContext ctx;
        private readonly IMapper mapper;
        public ReviewController(IMapper mapper, AutoLandDbContext ctx)
        {
            this.mapper = mapper;
            this.ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetAll()
        {

            return Ok(ctx.Reviews.ToArray()); 
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Reviews.Find(Id);

            if (item == null) return NotFound();

            return Ok(item);

        }

        [HttpPost]
        public IActionResult Create(CreateReviewModel model)
        {
            
            var car = ctx.Cars.FirstOrDefault(c => c.Id == model.CarId);
            var user = ctx.Users.FirstOrDefault(c => c.Id == model.RecieverId);
            if (model.CarId == null && model.RecieverId != null)
            {
                user.RewiewsReceived.Add(mapper.Map<Review>(model));
            }
            else
            {
               car.Reviews.Add(mapper.Map<Review>(model));
            } 
            if(model.CarId == null && model.RecieverId == null) 
            { 
               return NoContent();
            }

            ctx.SaveChanges();
            return Created(); 
        }

        [HttpPut]
        public IActionResult Edit(Review model)
        {
            ctx.Reviews.Update(model);
            ctx.SaveChanges();

            return Ok(); 
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Reviews.Find(id);

            if (item == null) return NotFound();

            ctx.Reviews.Remove(item);
            ctx.SaveChanges();

            return NoContent(); 
        }




    }
}
