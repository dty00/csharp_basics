using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PaintStore.API.Database;
using PaintStore.API.DTOs;
using PaintStore.Model;

namespace PaintStore.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly PaintStoreDbContext _dbContext;

    public UserController(PaintStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }



    [HttpPost]
    public IActionResult CreateUser([FromBody] UserCreateDto userCreateDto)
    {
        bool emailExists = _dbContext.Users
        .Any(u => u.Email == userCreateDto.Email);

        if (emailExists)
        {
            return Conflict("Email already exists");
        }
        User user = new User(userCreateDto.Name,userCreateDto.Email,userCreateDto.Phone);

        _dbContext.Users.Add(user);
        _dbContext.SaveChanges();

        UserResponseDto userResponse = ToUserResponseDto(user);
        return Created($"api/user/{userResponse.Id}",userResponse);
    }

    private static UserResponseDto ToUserResponseDto(User user)
{
    return new UserResponseDto
    {
        Id = user.Id,
        Name = user.Name,
        Email = user.Email,
        Phone = user.Phone,
        CreatedDate = user.CreatedDate
    };
}

}

