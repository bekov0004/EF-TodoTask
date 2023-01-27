using AutoMapper;
using Domain.Dtos;
using Domain.Entities;

namespace Infrastructure.MapperProfiles;

public class InfrastructureProfile:Profile
{
    public InfrastructureProfile()
    {
        CreateMap<User, Login>();
        CreateMap<User, Register>();
        CreateMap<Login, User>();
        
        CreateMap<Category, CategoryDto>();
        CreateMap<CategoryDto, Category>();
        
        CreateMap<TodoTask, AddTask>();
        CreateMap<AddTask, TodoTask>();
        
        CreateMap<Comment, CommentDto>();
        CreateMap<CommentDto, Comment>();
        
        CreateMap<AddUser, AddUserInTask>();
        CreateMap<AddUserInTask, AddUser>();

    }
}