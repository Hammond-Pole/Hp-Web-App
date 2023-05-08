﻿namespace Hp_Web_App.Shared.Models;

public class UserRole
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public ICollection<User>? Users { get; set; } // navigation property
}
