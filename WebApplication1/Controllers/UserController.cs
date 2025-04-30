using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApplication1;


namespace AutoLand_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private AutoLandDbContext ctx;
        private readonly IMapper mapper;

        public UserController(IMapper mapper, AutoLandDbContext ctx)
        {
            this.ctx = ctx;
            this.mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var a = ctx.Users.ToList();
            return Ok(a);
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Users.
                Include(u => u.OwnedCars).
                Include(u => u.Rents).
                Include(u => u.Payments).
                Include(u => u.Reviews).FirstOrDefault(u => u.Id == Id);
            if (item == null) return NotFound();

            var result = mapper.Map<UserDto>(item);

            return Ok(result);

        }

        [HttpPost]
        public IActionResult Create(CreateUserModel model)
        {

            ctx.Users.Add(mapper.Map<User>(model));
            ctx.SaveChanges();

            return Created(); 
        }

        [HttpPut]
        public IActionResult Edit(User model)
        {
            ctx.Users.Update(model);
            ctx.SaveChanges();

            return Ok(); 
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var item = ctx.Users.Find(id);

            if (item == null) return NotFound(); 

            ctx.Users.Remove(item);
            ctx.SaveChanges();

            return NoContent(); 
        }
    }
}
