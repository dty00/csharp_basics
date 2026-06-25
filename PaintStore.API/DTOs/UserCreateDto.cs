using System;
using System.ComponentModel.DataAnnotations;

namespace PaintStore.API.DTOs;

public class UserCreateDto
{
    [Required]
    public string Name {get;set;}

    [Required]
    [EmailAddress]
    public string Email{get;set;}

    [Required]
    [RegularExpression(@"^\+?\d{8,15}$")]
    public string Phone{get;set;}


}
