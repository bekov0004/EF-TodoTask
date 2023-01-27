using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController:ControllerBase
{
    private UserServices _userServices;

    public UserController(UserServices userServices)
    {
        _userServices = userServices;
    }

    [HttpGet("GetUser")]
    public async Task<Response<List<Register>>> GetUser()
    {
        return await _userServices.GetUser();
    }

    [HttpGet("Login")]
    public async Task<Response<List<Login>>> Login(Login login)
    {
        if(ModelState.IsValid)   
        {
           return await _userServices.Login(login); 
        }
        else    
        {
            return new Response<List<Login>>(HttpStatusCode.BadRequest, new List<string>() { "Not Found" });
        } 
    }

    [HttpPost("Registration")]
    public async Task<Response<Register>> Registre(Register register)
    {
        if (ModelState.IsValid)
        {
            return await _userServices.Registre(register);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<Register>(HttpStatusCode.BadRequest, errors);
        }
    }

}