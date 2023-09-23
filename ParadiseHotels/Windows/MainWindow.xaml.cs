using System;
using System.Windows;
using ParadiseHotels.Controls;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.Pages;

namespace ParadiseHotels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private SelectHotelPage _selectHotelPage;
        private EditHotelsPage _editHotelsPage;
        
        private Services.Services _services = new Services.Services();

        private DateTime _startDate = DateTime.Today;
        private DateTime _endDate = DateTime.Today.AddDays(10);
        private int _minPrice = 0;
        private int _maxPrice = -1;
        
        public MainWindow()
        {
            InitializeComponent();
            
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
            _selectHotelPage = new SelectHotelPage(
                _services, 
                _startDate, 
                _endDate, 
                _minPrice, 
                _maxPrice, 
                setFilters, 
                showBookings, 
                showEditHotelsPage
                );
            
            _selectHotelPage._onHotelClick += HotelOnMouseLeftButtonUp;
            Frame.Content = _selectHotelPage;
        }
        
        private void HotelOnMouseLeftButtonUp(object sender, EventArgs e)
        {
            Frame.Content = new SelectRoomPage(
                ((HotelComponent)sender)._hotel, 
                BookRoomButton_OnMouseLeftButtonUp, 
                BackToHotels, 
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

        private void BackToHotels()
        {
            Frame.Content = _selectHotelPage;
        }
        
        private void BackToNewHotels()
        {
            drawSelectHotelPage();
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
            Frame.Content = new BookingsPage(_services, BackToHotels);
        }

        private void showEditHotelsPage()
        {
            _editHotelsPage = new EditHotelsPage(_services, BackToNewHotels, showEditRoomsPage);
            Frame.Content = _editHotelsPage;
        }

        private void showEditRoomsPage(Hotel hotel)
        {
            Frame.Content = new EditRoomsPage(hotel, _services, backToEditHotelsPage);
        }

        private void backToEditHotelsPage()
        {
            Frame.Content = _editHotelsPage;
        }
    }
}