using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers;

[Authorize]
public class UsersController(IUserRepository userRepository) : BaseApiController
{
    [HttpGet] // /api/users
    public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
    {
        var users = await userRepository.GetUsersAsnyc();

        return Ok(users);
    }

    [HttpGet("{username}")]  // /api/users/2
    public async Task<ActionResult<MemeberDto>> GetUser(string username)
    {
        var user = await userRepository.GetUserByUsernameAsync(username);

        if (user == null) return NotFound();

        // return new MemeberDto
        // {
        //     Id = user.Id,
        //     KnownAs = user.KnownAs,
        //        .
        //        .
        //        .
        //        .
        // };
    }
}