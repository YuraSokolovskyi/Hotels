using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Controls;

public partial class EditRoomComponent : UserControl
{
    public delegate bool SaveChangesDelegate(Room room);
    public delegate void DeleteRoomDelegate(Room room);
    
    private Room _room;

    private SaveChangesDelegate _saveChanges;
    private DeleteRoomDelegate _deleteRoom;
    
    public EditRoomComponent(Room room, SaveChangesDelegate saveChanges, DeleteRoomDelegate deleteRoom)
    {
        InitializeComponent();

        _room = room;
        _saveChanges = saveChanges;
        _deleteRoom = deleteRoom;

        setData();
    }

    private void setData()
    {
        Price.Text = _room.Price.ToString();
        Bathrooms.Text = _room.Bathrooms.ToString();
        Bedrooms.Text = _room.Bedrooms.ToString();
        IsKitchen.Text = _room.IsKitchen ? "Yes" : "No";
        Area.Text = _room.Area.ToString();
        RoomType.Text = _room.RoomType;
    }

    private void Save_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _room.Area = Decimal.Parse(Area.Text);
            _room.Bedrooms = Int32.Parse(Bedrooms.Text);
            _room.Bathrooms = Int32.Parse(Bathrooms.Text);
            _room.IsKitchen = IsKitchen.Text == "Yes" ? true : false;
            _room.Price = Decimal.Parse(Price.Text);
            _room.RoomType = RoomType.Text;
            
            bool res = _saveChanges.Invoke(_room);
            if (res) RoomBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(64, 64, 64));
            else RoomBlock.BorderBrush = new SolidColorBrush(Colors.Red);
        }
        catch (Exception exception)
        {
            RoomBlock.BorderBrush = new SolidColorBrush(Colors.Red);
        }
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        _deleteRoom.Invoke(_room);
    }
}