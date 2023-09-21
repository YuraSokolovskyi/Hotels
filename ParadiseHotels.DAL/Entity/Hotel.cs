using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParadiseHotels.DAL.Entity;

public class Hotel
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public string Name { get; set; }
    
    [Required]
    [DefaultValue("")]
    public string Description { get; set; }
    
    [Required]
    [DefaultValue("")]
    public string City { get; set; }
    
    [Required]
    public string Address { get; set; }
    
    [Required]
    public string Email { get; set; }
    
    [Required]
    public string Phone { get; set; }
    
    public ICollection<Room> Rooms { get; set; }
}