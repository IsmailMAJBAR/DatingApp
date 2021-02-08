using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers {

  public class UsersController : BaseApiController {
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    public UsersController (IUserRepository userRepository, IMapper mapper) {
      _mapper = mapper;
      _userRepository = userRepository;
    }

    //return a list of users
    //use List insted of IEnumerable give more fontionnality (sort ...)
    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult<IEnumerable<MemberDto>>> GetUsers () {
      var users = await _userRepository.GetMembersAsync();
      return Ok(users);
    }
    //make it async by adding async Task<...> and await in the return and async list

    //return one user
    //api/users/3
    [Authorize]
    [HttpGet ("{username}")]
    public async Task<ActionResult<MemberDto>> GetUser (string username) {
  
      return  await _userRepository.GetMemberAsync (username);
    }
  }
}