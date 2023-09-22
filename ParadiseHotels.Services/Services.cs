using ParadiseHotels.DAL;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.DAL.Repositories;
using ParadiseHotels.Providers;

namespace ParadiseHotels.Services;

public class Services
{
    private ParadiseHotelsContext _context;

    private IRepository<Hotel> _hotelRepository;
    private HotelProvider _hotelProvider;
    
    public Services()
    {
        _context = new ParadiseHotelsContext();

        _hotelRepository = new Repository<Hotel>(_context);
    }
}