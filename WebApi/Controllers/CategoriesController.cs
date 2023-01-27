using System.Net;
using Domain.Dtos;
using Domain.Wrapper;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;
[ApiController]
[Route("[controller]")]
public class CategoriesController:ControllerBase
{
    private CategoryServices _categoryServices;

    public CategoriesController(CategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }
    [HttpGet("GetCategorie")]
    public async Task<Response<List<CategoryDto>>> GetCategorie()
    {
        return await _categoryServices.GetCategories();
    }

    [HttpPost("AddCategory")]
    public async Task<Response<CategoryDto>> AddCategory(CategoryDto categoryDto)
    {
        if (ModelState.IsValid)
        {
            return await _categoryServices.AddCategories(categoryDto);
        }
        else
        {
            var errors = ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage).ToList();
            return new Response<CategoryDto>(HttpStatusCode.BadRequest, errors);
        }
    }
    
}