using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ParadiseHotels.Controls;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Pages;

public partial class EditRoomsPage : Page
{
    public delegate void BackToEditHotelsPageDelegate();
    private Hotel _hotel;
    private Services.Services _services;
    private BackToEditHotelsPageDelegate _backToEditHotelsPage;
    
    public EditRoomsPage(Hotel hotel, Services.Services services, BackToEditHotelsPageDelegate backToEditHotelsPage)
    {
        InitializeComponent();
        _hotel = hotel;
        _services = services;
        _backToEditHotelsPage = backToEditHotelsPage;
        
        createRooms();
    }

    private void createRoom(Room room)
    {
        Rooms.Children.Add(new EditRoomComponent(room, saveChanges, deleteRoom));
    }

    private bool saveChanges(Room room)
    {
        if (_hotel.Rooms == null) _hotel.Rooms = new List<Room>();
        if (room.Id == 0) _hotel.Rooms.Add(room);
        return _services.updateHotel(_hotel);
    }
    
    private void deleteRoom(Room room)
    {
        _hotel.Rooms.Remove(room);
        _services.updateHotel(_hotel);
        
        Rooms.Children.Clear();
        createRooms();
    }

    private void createRooms()
    {
        foreach (Room room in _hotel.Rooms)
        {
            createRoom(room);
        }
    }

    private void AddNewRoom_OnClick(object sender, RoutedEventArgs e)
    {
        Rooms.Children.Add(new EditRoomComponent(new Room(), saveChanges, deleteRoom));
    }

    private void BackToEditHotels_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        _backToEditHotelsPage.Invoke();
    }
}