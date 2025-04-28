using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;


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

            return Ok(ctx.Users.ToArray());
        }

        [HttpGet("{Id}")]

        public IActionResult Get(int Id)
        {
            var item = ctx.Users.Find(Id);

            if (item == null) return NotFound();

            return Ok(item);

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
