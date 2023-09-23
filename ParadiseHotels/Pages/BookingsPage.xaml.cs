using System.Windows.Controls;
using System.Windows.Input;
using ParadiseHotels.Controls;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Pages;

public partial class BookingsPage : Page
{
    public delegate void BookingsBack();

    private BookingsBack _bookingsBack;
    private Services.Services _services;
    
    public BookingsPage(Services.Services services, BookingsBack bookingsBack)
    {
        InitializeComponent();

        _services = services;
        _bookingsBack = bookingsBack;
        
        createBookings();
    }

    private void createBooking(RoomBooking booking)
    {
        Bookings.Children.Add(new BookingComponent(booking));
    }

    private void createBookings()
    {
        foreach (RoomBooking booking in _services.getBookingByUser())
        {
            createBooking(booking);
        }
    }

    private void ImageBackMouseUp(object sender, MouseButtonEventArgs e)
    {
        _bookingsBack.Invoke();
    }
}