using DbContext;
using Features.Users.Models.DTOs;
using Features.Users.ApplicationService.Queries;
using Microsoft.EntityFrameworkCore;

namespace Features.Users.Services;

public class GetUser
{
    private readonly AppDbContext context;

    public GetUser(AppDbContext context)
    {
        this.context = context;
    }
    public async Task<UserDto> GetUserByPhoneNumberAsync(string phoneNumber)
    {
        return await context.Users.AsNoTracking().Select(u => new UserDto()
        {
            Id = u.Id,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            FirstName = u.FirstName,
            LastName = u.LastName
        }).SingleAsync(u => u.PhoneNumber == phoneNumber);
        
    }

    public async Task<UserDto> GetUserByEmailAsync(string email)
    {
        return await context.Users.AsNoTracking().Select(u => new UserDto()
        {
            Id = u.Id,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            FirstName = u.FirstName,
            LastName = u.LastName
        }).SingleAsync(u => u.Email == email);
    }

    public async Task<UserDto> GetUserByIdAsync(long userId)
    {
        return await context.Users.Select(u => new UserDto()
        {
            Id = u.Id,
            Email = u.Email,
            PhoneNumber = u.PhoneNumber,
            FirstName = u.FirstName,
            LastName = u.LastName
        }).SingleOrDefaultAsync(u => u.Id == userId);
    }
}