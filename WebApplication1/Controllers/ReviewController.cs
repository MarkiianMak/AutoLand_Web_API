using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using System.Diagnostics.Eventing.Reader;
using Microsoft.EntityFrameworkCore;

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


        [HttpPost("Car{Id}")]
        public IActionResult Create(CreateCarReviewModel model, int Id)
        {

            var car = ctx.Cars.Find(Id);
            if(car == null) 
            { 
               return NoContent();
            }
            car.Reviews.Add(mapper.Map<Review>(model));
            ctx.SaveChanges();

            return Created(); 
        }

        [HttpPost("User{Id}")]
        public IActionResult Create(CreateUserReviewModel model, int Id)
        {
            var user = ctx.Users.Find(Id);
        
          
            if (user == null)
            {
                return NoContent();
            }
            user.Reviews.Add(mapper.Map<Review>(model));

            ctx.SaveChanges();

            return Created();
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Users.Include(u => u.Reviews).FirstOrDefault(u => u.Id == Id);
            if (item == null) return NotFound();


            return Ok(item.Reviews.ToList());

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
