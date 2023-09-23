using System;
using System.Windows;
using ParadiseHotels.Controls;
using ParadiseHotels.Pages;

namespace ParadiseHotels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private SelectHotelPage _selectHotelPage;
        private Services.Services _services = new Services.Services();

        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today.AddDays(10);
        private int _minPrice = 0;
        private int _maxPrice = -1;
        
        public MainWindow()
        {
            InitializeComponent();
            
            // drawSelectHotelPage();
            Frame.Content = new LogInPage(_services, loggedIn, goToRegistration);
        }

        private void setFilters(DateTime startDate, DateTime endDate, int minPrice, int maxPrice)
        {
            _startDate = startDate;
            _endDate = endDate;

            _minPrice = minPrice;
            _maxPrice = maxPrice;

            drawSelectHotelPage();
        }

        private void drawSelectHotelPage()
        {
            _selectHotelPage = new SelectHotelPage(_services, _startDate, _endDate, _minPrice, _maxPrice, setFilters, showBookings);
            _selectHotelPage._onHotelClick += HotelOnMouseLeftButtonUp;
            Frame.Content = _selectHotelPage;
        }
        
        private void HotelOnMouseLeftButtonUp(object sender, EventArgs e)
        {
            Frame.Content = new SelectRoomPage(
                ((HotelComponent)sender)._hotel, 
                BookRoomButton_OnMouseLeftButtonUp, 
                BookRoomBack, 
                _startDate, 
                _endDate,
                _minPrice,
                _maxPrice);
        }

        private void BookRoomButton_OnMouseLeftButtonUp(object sender, EventArgs e)
        {
            _services.bookRoom(((RoomComponent)(sender))._room, _startDate, _endDate);

            drawSelectHotelPage();
        }

        private void BookRoomBack()
        {
            Frame.Content = _selectHotelPage;
        }

        private void registeredNewUser()
        {
            Frame.Content = new LogInPage(_services, loggedIn, goToRegistration);
        }
        
        private void goToRegistration()
        {
            Frame.Content = new RegisterPage(_services, registeredNewUser, goToLogIn);
        }
        
        private void goToLogIn()
        {
            Frame.Content = new LogInPage(_services, loggedIn, goToRegistration);
        }

        private void loggedIn()
        {
            drawSelectHotelPage();
        }

        private void showBookings()
        {
            Frame.Content = new BookingsPage(_services, BookRoomBack);
        }
    }
}