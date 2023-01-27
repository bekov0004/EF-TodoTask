using System.Net;
using AutoMapper;
using Domain.Dtos;
using Domain.Entities;
using Domain.Wrapper;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Services;

public class CommentServices
{
    private readonly DataContext _context;
    private readonly IMapper _mapper;

    public CommentServices(DataContext context,IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<Response<List<CommentDto>>> GetComment()
    {
        var result = await _context.Comments.ToListAsync();
        return new Response<List<CommentDto>>(_mapper.Map<List<CommentDto>>(result));
    }
    
    
    public async Task<Response<CommentDto>> AddComment(CommentDto commentDto)
    {
        try
        {
            var mapped = _mapper.Map<Comment>(commentDto);
            await _context.Comments.AddAsync(mapped);
            await _context.SaveChangesAsync();
            return new Response<CommentDto>(commentDto);

        }
        catch (Exception ex)
        {
            return new Response<CommentDto>(HttpStatusCode.InternalServerError, new List<string>() { ex.Message });
        }
    }
}