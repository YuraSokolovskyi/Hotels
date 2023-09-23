using System.Windows.Controls;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Controls;

public partial class BookingComponent : UserControl
{
    private RoomBooking _booking;
    
    public BookingComponent(RoomBooking booking)
    {
        InitializeComponent();

        _booking = booking;
        
        setData();
    }
    
    private void setData()
    {
        StartDate.Text = $"{_booking.BookingStart.Year}-{_booking.BookingStart.Month}-{_booking.BookingStart.Day}";
        EndDate.Text = $"{_booking.BookingEnd.Year}-{_booking.BookingEnd.Month}-{_booking.BookingEnd.Day}";
        Area.Text = _booking.Room.Area.ToString();
        Bedrooms.Text = _booking.Room.Bedrooms.ToString();
        Bathrooms.Text = _booking.Room.Bathrooms.ToString();
        IsKitchen.Text = _booking.Room.IsKitchen ? "Yes" : "No";
        RoomType.Text = _booking.Room.RoomType;
        Price.Text = _booking.Room.Price.ToString();
        Name.Text = _booking.Room.Hotel.Name;
        HotelAddress.Text = _booking.Room.Hotel.Address;
        City.Text = _booking.Room.Hotel.City;
        
        TotalPrice.Text = (_booking.Room.Price * (_booking.BookingEnd - _booking.BookingStart).Days).ToString();
    }
}