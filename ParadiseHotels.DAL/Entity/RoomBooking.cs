using System.ComponentModel.DataAnnotations;

namespace ParadiseHotels.DAL.Entity;

public class RoomBooking
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public int UserId { get; set; }
    
    [Required]
    public DateTime BookingStart { get; set; }
    
    [Required]
    public DateTime BookingEnd { get; set; }
    
    public virtual Room Room { get; set; }
    
    public User User { get; set; }
}