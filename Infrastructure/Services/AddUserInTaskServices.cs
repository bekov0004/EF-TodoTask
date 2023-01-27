using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class AddUserInTaskServices
{
    
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public AddUserInTaskServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<Response<List<AddUserInTask>>> GetUser()
    {
        var result = await _context.AddUsers.ToListAsync();
        return new Response<List<AddUserInTask>>(_mapper.Map<List<AddUserInTask>>(result));
    }
    public async Task<Response<AddUserInTask>> AddUser(AddUserInTask addUserInTask)
    {
        try
        {
            var mapped = _mapper.Map<AddUser>(addUserInTask);
            await _context.AddUsers.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<AddUserInTask>(addUserInTask);

        }
        catch (Exception ex)
        {
            return new Response<AddUserInTask>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}