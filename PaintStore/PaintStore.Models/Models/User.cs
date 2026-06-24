using System;

namespace PaintStore.Model;

public class User
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; private set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }

    public User(string name, string email, string phone)
    {
        Name = name;
        CreatedDate = DateTime.Now;
        Email = email;
        Phone = phone;
    }

}
