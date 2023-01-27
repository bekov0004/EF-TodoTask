using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddTaskServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AddTaskServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<AddTask>>> GetTask()
    {
        var result = await _context.TodoTasks.ToListAsync();
        return new Response<List<AddTask>>(_mapper.Map<List<AddTask>>(result));
    }
    public async Task<Response<AddTask>> AddTask(AddTask addTask)
    {
        try
        {
            var mapped = _mapper.Map<TodoTask>(addTask);
            await _context.TodoTasks.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddTask>(addTask);
        }
        catch (Exception ex)
        {
            return new Response<AddTask>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}