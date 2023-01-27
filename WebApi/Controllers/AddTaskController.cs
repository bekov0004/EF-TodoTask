using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class AddTaskController:ControllerBase
{
    private AddTaskServices _addTaskServices;

    public AddTaskController(AddTaskServices addTaskServices)
    {
        _addTaskServices = addTaskServices;
    }
    
    [HttpGet("GetTask")]
    public async Task<Response<List<AddTask>>> GetTask()
    {
        return await _addTaskServices.GetTask();
    }

    [HttpPost("AddTask")]
    public async Task<Response<AddTask>> AddTask(AddTask addTask)
    {
        if (ModelState.IsValid)
        {
            return await _addTaskServices.AddTask(addTask);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<AddTask>(HttpStatusCode.BadRequest, errors);
        }
    }
}