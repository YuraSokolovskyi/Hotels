using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Media;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels;

public partial class HotelComponent : UserControl
{
    public Hotel _hotel { get; set; }
    
    public HotelComponent()
    {
        InitializeComponent();
    }
    
    public HotelComponent(Hotel hotel)
    {
        InitializeComponent();

        _hotel = hotel;
        
        setData();
    }

    private void setData()
    {
        HotelName.Text = _hotel.Name;
        HotelAddress.Text = _hotel.Address;
        HotelDescription.Text = _hotel.Description;
        Email.Text = _hotel.Email;
        Phone.Text = _hotel.Phone;
        City.Text = _hotel.City;
    }

    private void UIElement_OnMouseEnter(object sender, MouseEventArgs e)
    {
        HotelBlock.Background = new SolidColorBrush(Color.FromArgb(50, 0, 53, 128));
        HotelBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 50, 144));
    }

    private void HotelBlock_OnMouseLeave(object sender, MouseEventArgs e)
    {
        HotelBlock.Background = null;
        HotelBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(64, 64, 64));
    }

    private void HotelBlock_OnMouseMove(object sender, MouseEventArgs e)
    {
        HotelBlock.Background = new SolidColorBrush(Color.FromArgb(50, 0, 53, 128));
        HotelBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(0, 50, 144));
    }
}