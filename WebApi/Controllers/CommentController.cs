using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CommentController:ControllerBase
{
    private CommentServices _commentServices;

    public CommentController(CommentServices commentServices)
    {
        _commentServices = commentServices;
    }

    [HttpGet("GetComment")]
    public async Task<Response<List<CommentDto>>> GetComment()
    {
        return await _commentServices.GetComment();
    }

    [HttpPost("AddComment")]
    public async Task<Response<CommentDto>> AddComment(CommentDto commentDto)
    {
        if (ModelState.IsValid)
        {
            return await _commentServices.AddComment(commentDto);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<CommentDto>(HttpStatusCode.BadRequest, errors);
        }
    }
}