using System;
using System.Linq;
using System.Windows.Controls;
using System.Windows.Input;
using ParadiseHotels.Controls;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Pages;

public partial class SelectRoomPage : Page
{
    public delegate void RoomBookBack();
    
    public event MouseButtonEventHandler _onRoomBook;
    public event RoomBookBack _roomBookBack;
    
    private Hotel _hotel;
    
    private DateTime _startDate;
    private DateTime _endDate;
    private int _minPrice;
    private int _maxPrice;
    
    public SelectRoomPage(Hotel hotel, MouseButtonEventHandler onRoomBook, RoomBookBack back, DateTime startDate, DateTime endDate, int minPrice, int maxPrice)
    {
        InitializeComponent();

        _onRoomBook = onRoomBook;
        _roomBookBack = back;
        _hotel = hotel;
        _startDate = startDate;
        _endDate = endDate;
        _minPrice = minPrice;
        _maxPrice = maxPrice;

        createRooms();
    }
    
    private void createRoom(Room room)
    {
        RoomComponent roomComponent = new RoomComponent(room, _startDate, _endDate);
        roomComponent.MouseUp += bookRoom;
            
        Rooms.Children.Add(roomComponent);
    }

    private void createRooms()
    {
        foreach (Room room in Services.Services.getFreeRooms(_hotel.Rooms.ToList(), _startDate, _endDate))
        {
            if ((room.Price >= _minPrice && room.Price <= _maxPrice) || _maxPrice == -1) createRoom(room);
        }
    }

    private void bookRoom(object sender, MouseButtonEventArgs e)
    {
        _onRoomBook.Invoke(sender, e);
    }

    private void ImageBackMouseUp(object sender, MouseButtonEventArgs e)
    {
        _roomBookBack.Invoke();
    }
}