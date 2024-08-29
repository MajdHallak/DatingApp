using System;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class BuggyController(DataContext context) : BaseApiController
{
    [Authorize]
    [HttpGet("auth")]
    public ActionResult<string> GetAuth()
    {
        return "Secret Text";
    }

    [HttpGet("not-found")]
    public ActionResult<AppUser> GetNotFound()
    {
        // find user with id = -1 which doesnt exist.
        var thing = context.Users.Find(-1);

        if (thing == null) return NotFound();

        return thing;
    }

    [HttpGet("server-error")]
    public ActionResult<AppUser> GetServerError()
    {
        var thing = context.Users.Find(-1) ?? throw new Exception("Cannot find a user with id=-1");

        return thing;
    }


    [HttpGet("bad-request")]
    // typically HTTP 400 to 499 type of response, user related errors.
    public ActionResult<string> GetBadRequest()
    {
        return BadRequest("This was not a good request!");
    }
}
