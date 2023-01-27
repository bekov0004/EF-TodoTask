using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AddUserInTaskController:ControllerBase
{
    private AddUserInTaskServices _addUserInTaskServices;

    public AddUserInTaskController(AddUserInTaskServices addUserInTaskServices)
    {
        _addUserInTaskServices = addUserInTaskServices;
    }
    
    [HttpGet("GetUser")]
    public async Task<Response<List<AddUserInTask>>> GetUser()
    {
        return await _addUserInTaskServices.GetUser();
    }
    
    [HttpPost("AddUserInTask")]
    public async Task<Response<AddUserInTask>> Registre(AddUserInTask addUserInTask)
    {
        if (ModelState.IsValid)
        {
            return await _addUserInTaskServices.AddUser(addUserInTask);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddUserInTask>(HttpStatusCode.BadRequest, errors);
        }
    }
}