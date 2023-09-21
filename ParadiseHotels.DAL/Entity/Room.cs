using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ParadiseHotels.DAL.Entity;

public class Room
{
    [Key]
    public int Id { get; set; }
    
    [Required]
    public decimal Price { get; set; }
    
    [Required]
    [DefaultValue(0)]
    public int Bedrooms { get; set; }
    
    [Required]
    [DefaultValue(0)]
    public int Bathrooms { get; set; }
    
    [Required]
    public bool IsKitchen { get; set; }
    
    [Required]
    [DefaultValue(0)]
    public decimal Area { get; set; }
    
    [Required]
    public string RoomType { get; set; }
    
    [Required]
    public virtual Hotel Hotel { get; set; }
    
    // public virtual RoomsStatus RoomsStatus { get; set; }
}