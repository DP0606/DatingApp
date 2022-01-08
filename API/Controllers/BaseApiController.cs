using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController] //Automatski validira parametre koji se šalju u API!
    //Ovo je poziv kod routinga, poziva se classa UserController bez naziva controller //api/users/
    [Route("api/[controller]")]
    public class BaseApiController : ControllerBase
    {
        
    }
}