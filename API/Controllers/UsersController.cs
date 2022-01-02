using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    //Ovo je poziv kod routinga, poziva se classa UserController bez naziva controller //api/users/
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;

        }

        //api/users/
        /*[HttpGet]
        public ActionResult<IEnumerable<AppUser>> GetUsers()
        {
            //Ovo baš nije skalabilno jer dohvaćamo istovremeno samo jedan set podataka
            //Riješenje je mulithread.
            return _context.Users.ToList();   

        }*/

        //Async način rada!
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            return await _context.Users.ToListAsync();   
        }

        //api/users/{3}
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            return await _context.Users.FindAsync(id);   

        }

    }
}