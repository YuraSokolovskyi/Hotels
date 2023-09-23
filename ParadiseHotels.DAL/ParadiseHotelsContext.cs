using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.DAL;

public class ParadiseHotelsContext : DbContext
{
    private string _connectionString = "Data Source=localhost;Initial Catalog=ParadiseHotels;Integrated Security=true;TrustServerCertificate=True;Connection Timeout=30;";

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomBooking> RoomBooking { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }
}