using Newtonsoft.Json;
using ParadiseHotels.DAL;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.DAL.Repositories;
using ParadiseHotels.Providers;
using ParadiseRoomsStatus.Providers;
using ParadiseUsers.Providers;

namespace Services;

class TestData
{
    public List<User> Users { get; set; }
    public List<Hotel> Hotels { get; set; }
}

public class Services
{
    public enum registerErrors
    {
        EmailIsTaken,
        PhoneIsTaken,
        EmptyField,
        Success
    }
    
    private ParadiseHotelsContext _context;

    private IRepository<Hotel> _hotelRepository;
    private HotelProvider _hotelProvider;
    
    private IRepository<Room> _roomRepository;
    private RoomProvider _roomProvider;
    
    private IRepository<User> _userRepository;
    private UserProvider _userProvider;
    
    private IRepository<RoomBooking> _roomBookingRepository;
    private RoomBookingProvider _roomBookingProvider;
    
    private List<Hotel> _hotels;
    private List<Room> _rooms;
    private List<User> _users;
    private List<RoomBooking> _roomBookings;

    private User User;

    public Services()
    {
        _context = new ParadiseHotelsContext();

        _hotelRepository = new Repository<Hotel>(_context);
        _hotelProvider = new HotelProvider(_hotelRepository);

        _roomRepository = new Repository<Room>(_context);
        _roomProvider = new RoomProvider(_roomRepository);

        _userRepository = new Repository<User>(_context);
        _userProvider = new UserProvider(_userRepository);
        
        _roomBookingRepository = new Repository<RoomBooking>(_context);
        _roomBookingProvider = new RoomBookingProvider(_roomBookingRepository);
             
        _hotels = _hotelProvider.GetHotels().ToList();
        _rooms = _roomProvider.GetRooms().ToList();
        _users = _userProvider.GetUsers().ToList();
        _roomBookings = _roomBookingProvider.GetRoomBookings().ToList();
        
        // test data
        // uploadTestData();
    }

    public List<Hotel> getHotels()
    {
        return _hotels;
    }

    public registerErrors registerUser(
        string name,
        string lastName,
        string middleName,
        string email,
        string password,
        string phone,
        string city,
        string address)
    {
        if (name.Trim() == "" ||
            lastName.Trim() == "" ||
            middleName.Trim() == "" ||
            email.Trim() == "" ||
            password.Trim() == "" ||
            phone.Trim() == "" ||
            city.Trim() == "" ||
            address.Trim() == "") return registerErrors.EmptyField;
        if (_userProvider.getUserByEmail(email) != null) return registerErrors.EmailIsTaken;
        if (_userProvider.getUserByPhone(phone) != null) return registerErrors.PhoneIsTaken;
        
        _userProvider.AddUser(new User()
        {
            FirstName = name,
            LastName = lastName,
            MiddleName = middleName,
            Email = email,
            Password = password,
            Phone = phone,
            City = city,
            Address = address,
            Type = 0
        });
        return registerErrors.Success;
    }

    public bool logIn(string email, string password)
    {
        User user = _userProvider.getUserByEmail(email);
        if (user != null && user.Password == password)
        {
            User = user;
            return true;
        }

        return false;
    }
    
    public int bookRoom(Room room, DateTime startDate, DateTime endDate)
    {
        if (isRoomFree(room, startDate, endDate))
        {
            _roomProvider.AddBooking(room, startDate, endDate, User.Id);
            return 1;
        }

        return 0;
    }

    public static List<Room> getFreeRooms(List<Room> rooms, DateTime startDate, DateTime endDate)
    {
        return rooms.Select(room => room).Where(room => isRoomFree(room, startDate, endDate)).ToList();
    }

    public static List<Hotel> getHotelsWithFreeRooms(List<Hotel> hotels, DateTime startDate, DateTime endDate)
    {
        List<Hotel> result = new List<Hotel>();

        foreach (Hotel hotel in hotels)
        {
            if (hotel.Rooms == null) continue;
            if (getFreeRooms(hotel.Rooms.ToList(), startDate, endDate).Count != 0) result.Add(hotel);
        }
        
        return result;
    }

    public static bool isRoomFree(Room room, DateTime startDate, DateTime endDate)
    {
        if (room.RoomBooking == null) return true;
        
        foreach (RoomBooking roomBooking in room.RoomBooking)
        {
            if (startDate < roomBooking.BookingEnd && endDate > roomBooking.BookingStart) return false;
        }
        return true;
    }

    public static bool isHotelAffordable(Hotel hotel, int minPrice, int maxPrice)
    {
        foreach (Room room in hotel.Rooms)
            if (room.Price >= minPrice && room.Price <= maxPrice)
                return true;

        return false;
    }

    public List<RoomBooking> getBookingByUser()
    {
        return _roomBookingProvider.GetRoomBookings().Where(booking => booking.UserId == User.Id).ToList();
    }

    public bool updateHotel(Hotel hotel)
    {
        if (hotel.Id == 0)
        {
            if (hotel.Name == "" ||
                hotel.Address == "" ||
                hotel.City == "" ||
                hotel.Email == "" ||
                hotel.Phone == "" ||
                hotel.Description == "") return false;
            else
            {
                hotel.Rooms = new List<Room>();
                _hotelProvider.AddHotel(hotel);
                _hotels = _hotelProvider.GetHotels().ToList();
                _rooms = _roomProvider.GetRooms().ToList();
                return true;
            }
        }
        else
        {
            _hotelProvider.UpdateHotel(hotel);
            _hotels = _hotelProvider.GetHotels().ToList();
            _rooms = _roomProvider.GetRooms().ToList();
            return true;
        }
    }

    public void deleteHotel(Hotel hotel)
    {
        _hotelProvider.DeleteHotelById(hotel.Id);
        _hotels = _hotelProvider.GetHotels().ToList();
    }
    
    public void uploadTestData()
    {
        string jsonPath = "D:\\C#\\Hotels\\ParadiseHotels.Services\\ParadiseHotels.Services\\TestData\\RoomsData.json";
        string content = File.ReadAllText(jsonPath);
        
        TestData testData = JsonConvert.DeserializeObject<TestData>(content);
        _userProvider.AddUsers(testData.Users);
        _hotelProvider.AddHotels(testData.Hotels);
    }
}