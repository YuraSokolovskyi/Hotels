﻿using System.ComponentModel.DataAnnotations;

namespace ParadiseHotels.DAL.Entity;

public class User
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string FirstName { get; set; }
    
    [Required]
    public string LastName { get; set; }
    
    [Required]
    public string MiddleName { get; set; }
    
    [Required]
    public string Phone { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string City { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    public string Password { get; set; }
    
    [Required]
    public int Type { get; set; }
}