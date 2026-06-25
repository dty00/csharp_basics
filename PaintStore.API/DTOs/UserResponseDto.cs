using System;

namespace PaintStore.API.DTOs;

public class UserResponseDto
{
    public string Name { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public int Id { get; set; }

    public DateTime CreatedDate { get; set; }
}
