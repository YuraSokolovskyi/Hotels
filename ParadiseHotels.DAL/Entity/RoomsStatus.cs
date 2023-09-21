using System.ComponentModel.DataAnnotations;

namespace ParadiseHotels.DAL.Entity;

public class RoomsStatus
{
    [Key]
    public int Id { get; set; }
    
    // [Required]
    // public Room Room { get; set; }
    
    // [Required]
    // public User User { get; set; }
    
    [Required]
    public DateTime BookingStart { get; set; }
    
    [Required]
    public DateTime BookingEnd { get; set; }
}