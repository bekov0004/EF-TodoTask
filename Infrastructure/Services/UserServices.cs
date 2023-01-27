using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class UserServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public UserServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<Register>>> GetUser()
    {
        var result = await _context.Users.ToListAsync();
        return new Response<List<Register>>(_mapper.Map<List<Register>>(result));
    }
    
    public async Task<Response<List<Login>>> Login(Login login)
    {
        var result = await _context.Users.FirstOrDefaultAsync(x => x.Name == login.Name && x.PassWord == login.PassWord);
        return new Response<List<Login>>(_mapper.Map<List<Login>>(result));
    }
    
    
    public async Task<Response<Register>> Registre(Register register)
    {
        try
        {
            var mapped = _mapper.Map<User>(register);
            await _context.Users.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<Register>(register);

        }
        catch (Exception ex)
        {
            return new Response<Register>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}