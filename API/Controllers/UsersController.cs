using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

  public class UsersController : BaseApiController {
    private readonly DataContext _context;
    public UsersController (DataContext context) {
      _context = context;
    }


    //return a list of users
    //use List insted of IEnumerable give more fontionnality (sort ...)
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers(){
        return await _context.Users.ToListAsync();
    }
    //make it async by adding async Task<...> and await in the return and async list

    //return one user
    //api/users/3
    [Authorize]
    [HttpGet("{id}")]
    public async Task<ActionResult<AppUser>> GetUser(int id){
        return await _context.Users.FindAsync(id);
    }
  }
}