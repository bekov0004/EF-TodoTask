using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CategoryServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CategoryServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<CategoryDto>>> GetCategories()
    {
        var result = await _context.Categories.ToListAsync();
        return new Response<List<CategoryDto>>(_mapper.Map<List<CategoryDto>>(result));
    }
    
    
    public async Task<Response<CategoryDto>> AddCategories(CategoryDto categoryDto)
    {
        try
        {
            var mapped = _mapper.Map<Category>(categoryDto);
            await _context.Categories.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<CategoryDto>(categoryDto);

        }
        catch (Exception ex)
        {
            return new Response<CategoryDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
    
}