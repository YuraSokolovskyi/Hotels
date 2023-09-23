using System;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Controls;

public partial class RoomComponent : UserControl
{
    public Room _room;
    private DateTime _startDate;
    private DateTime _endDate;
    
    public RoomComponent(Room room, DateTime startDate, DateTime endDate)
    {
        InitializeComponent();

        _room = room;
        _startDate = startDate;
        _endDate = endDate;
        
        setData();
    }

    private void setData()
    {
        Area.Text = _room.Area.ToString();
        Bedrooms.Text = _room.Bedrooms.ToString();
        Bathrooms.Text = _room.Bathrooms.ToString();
        IsKitchen.Text = _room.IsKitchen ? "Yes" : "No";
        RoomType.Text = _room.RoomType;
        Price.Text = _room.Price.ToString();

        TotalPrice.Text = (_room.Price * (_endDate - _startDate).Days).ToString();
    }

    private void RoomBlock_OnMouseEnter(object sender, MouseEventArgs e)
    {
        RoomBlock.Background = new SolidColorBrush(Color.FromArgb(50, 0, 53, 128));
        RoomBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 50, 144));
    }

    private void RoomBlock_OnMouseLeave(object sender, MouseEventArgs e)
    {
        RoomBlock.Background = null;
        RoomBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(64, 64, 64));
    }

    private void RoomBlock_OnMouseMove(object sender, MouseEventArgs e)
    {
        RoomBlock.Background = new SolidColorBrush(Color.FromArgb(50, 0, 53, 128));
        RoomBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 50, 144));
    }
}