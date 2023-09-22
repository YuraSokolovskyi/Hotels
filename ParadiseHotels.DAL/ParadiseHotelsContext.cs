using System.Configuration;
using Microsoft.EntityFrameworkCore;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.DAL;

public class ParadiseHotelsContext : DbContext
{
    // private string _connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ToString();
    private string _connectionString = "Data Source=localhost;Initial Catalog=ParadiseHotels;Integrated Security=true;TrustServerCertificate=True;Connection Timeout=30;";

    public DbSet<Hotel> Hotels { get; set; }
    public DbSet<Room> Rooms { get; set; }
    public DbSet<RoomBooking> RoomsStatuses { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(_connectionString);
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // connections
        // modelBuilder.Entity<Hotel>()
        //     .HasMany(hotel => hotel.Rooms)
        //     .WithOne(room => room.Hotel)
        //     .HasForeignKey(room => room.Id);
        // modelBuilder.Entity<City>()
        //     .HasOne(city => city.Country)
        //     .WithMany(country => country.City)
        //     .HasForeignKey(country => country.Id);
        //
        // modelBuilder.Entity<Hotel>()
        //     .HasOne(hotel => hotel.City)
        //     .WithMany(city => city.Hotel)
        //     .HasForeignKey(city => city.Id);
        //
        // modelBuilder.Entity<Room>()
        //     .HasOne(room => room.RoomType)
        //     .WithMany(roomType => roomType.Rooms)
        //     .HasForeignKey(roomType => roomType.Id);
        //
        // modelBuilder.Entity<RoomBooking>()
        //     .HasOne(roomsStatus => roomsStatus.Room)
        //     .WithMany(room => room.RoomBooking)
        //     .HasForeignKey(room => room.Id);
        //
        // modelBuilder.Entity<RoomBooking>()
        //     .HasOne(roomsStatus => roomsStatus.User)
        //     .WithMany(user => user.RoomBooking)
        //     .HasForeignKey(user => user.Id)
        //     .OnDelete(DeleteBehavior.Restrict);
        //
        // modelBuilder.Entity<User>()
        //     .HasOne(user => user.City)
        //     .WithMany(city => city.User)
        //     .HasForeignKey(city => city.Id);
        //
        // modelBuilder.Entity<Room>()
        //     .HasOne(room => room.Hotel)
        //     .WithMany(hotel => hotel.Rooms)
        //     .HasForeignKey(hotel => hotel.Id);
        
        
        // // TEST DATA
        // // Countries
        // var country1 = new Country() { Id = 1, Name = "Ukraine" };
        // var country2 = new Country() { Id = 2, Name = "Canada" };
        // var country3 = new Country() { Id = 3, Name = "Germany" };
        // modelBuilder.Entity<Country>().HasData(country1, country2, country3);
        //
        // // Cities
        // var city1 = new City() { Id = 1, Name = "Kyiv", Country = country1 };
        // var city2 = new City() { Id = 2, Name = "Lviv", Country = country1 };
        // var city3 = new City() { Id = 3, Name = "Ottawa", Country = country2 };
        // var city4 = new City() { Id = 4, Name = "Toronto", Country = country2 };
        // var city5 = new City() { Id = 5, Name = "Quebec", Country = country2 };
        // var city6 = new City() { Id = 6, Name = "Berlin", Country = country3 };
        // var city7 = new City() { Id = 7, Name = "Cologne", Country = country3 };
        // var city8 = new City() { Id = 8, Name = "Frankfurt", Country = country3 };
        // modelBuilder.Entity<City>().HasData(city1, city2, city3, city4, city5, city6, city7, city8);
        //
        // // RoomTypes
        // var roomType1 = new RoomsType() { Id = 1, Type = "Economy" };
        // var roomType2 = new RoomsType() { Id = 2, Type = "Premium" };
        // modelBuilder.Entity<RoomsType>().HasData(roomType1, roomType2);
        //
        // // Hotels
        // var hotel1 = new Hotel()
        // {
        //     Id = 1, Name = "Glacier Mountaineer Lodge",
        //     Address = "1549 Kicking Horse Trail (PO Box 2310), V0A 1H0 Golden", City = city3,
        //     Description = "test description", Email = "test@gmail.com", Phone = "+38050485956564"
        // };
        // var hotel2 = new Hotel()
        // {
        //     Id = 2, Name = "Ponderosa Motor Inn",
        //     Address = "1206 Transcanada Highway, V0A 1H0 Golden", City = city3,
        //     Description = "test description", Email = "test2@gmail.com", Phone = "+380995435644"
        // };
        // modelBuilder.Entity<Hotel>().HasData(hotel1, hotel2);
        //
        // // Rooms
        // var room1 = new Room()
        // {
        //     Id = 1, RoomType = roomType1, Description = "testDescription", Hotel = hotel1, Area = 12.5m, Bathrooms = 1,
        //     Bedrooms = 1, Price = 100, IsKitchen = true
        // };
        // var room2 = new Room()
        // {
        //     Id = 2, RoomType = roomType1, Description = "testDescription", Hotel = hotel1, Area = 12.5m, Bathrooms = 1,
        //     Bedrooms = 1, Price = 125, IsKitchen = true
        // };
        // var room3 = new Room()
        // {
        //     Id = 3, RoomType = roomType2, Description = "testDescription", Hotel = hotel2, Area = 12.5m, Bathrooms = 1,
        //     Bedrooms = 1, Price = 250, IsKitchen = true
        // };
        // var room4 = new Room()
        // {
        //     Id = 4, RoomType = roomType2, Description = "testDescription", Hotel = hotel2, Area = 12.5m, Bathrooms = 1,
        //     Bedrooms = 2, Price = 300, IsKitchen = true
        // };
        // modelBuilder.Entity<Room>().HasData(room1, room2, room3, room4);
        
        base.OnModelCreating(modelBuilder);
    }
}