using API.Entities;

namespace API.Interfaces
{
    //Razlika classe i interface-a. Interface ne sadrži implementacijsku logiku sam funkcionalnost.
    public interface ITokenService //Interface uvijek ima prefiks I
    {
        string CreateToken(AppUser user);
    }
}