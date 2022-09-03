using Microsoft.AspNetCore.Mvc;
using redisAPI.Data;
using redisAPI.Models;

namespace redisAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _repo;

        public PlatformController(IPlatformRepo repo)
        {
            _repo = repo;
        }

        [HttpPost]
        public  ActionResult<Platform>  CreatePlatform(Platform platform){
           
             _repo.CreatePlatform(platform);

             return CreatedAtRoute("GetPlatformById", new{id=platform.Id},platform);
        }


        [HttpGet("{id}",Name = "GetPlatformById")]
        public ActionResult<Platform> GetPlatformById([FromQuery]string id){
           var platform= _repo.GetPlatformById(id);

          if(platform!=null)
             return Ok(platform);

         return NotFound();

        }

       [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetAllPlatforms(){
            return  Ok(_repo.GetAllPlatforms());
        }
    }
}