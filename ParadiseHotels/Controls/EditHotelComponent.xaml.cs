using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Controls;

public partial class EditHotelComponent : UserControl
{
    public delegate bool SaveChangesDelegate(Hotel hotel);
    public delegate void DeleteChangesDelegate(Hotel hotel);
    public delegate void EditRoomsDelegate(Hotel hotel);
    private Hotel _hotel;
    private SaveChangesDelegate _saveChanges;
    private DeleteChangesDelegate _deleteChanges;
    private EditRoomsDelegate _editRooms;
    
    public EditHotelComponent(Hotel hotel, SaveChangesDelegate saveChanges, DeleteChangesDelegate deleteChanges, EditRoomsDelegate editRooms)
    {
        InitializeComponent();

        _hotel = hotel;
        _saveChanges = saveChanges;
        _deleteChanges = deleteChanges;
        _editRooms = editRooms;
        
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

    private void Save_OnClick(object sender, RoutedEventArgs e)
    {
        _hotel.Name = HotelName.Text;
        _hotel.Address = HotelAddress.Text;
        _hotel.Description = HotelDescription.Text;
        _hotel.City = City.Text;
        _hotel.Phone = Phone.Text;
        _hotel.Email = Email.Text;
        
        bool res = _saveChanges.Invoke(_hotel);
        if (res)
        {
            HotelBlock.BorderBrush = new SolidColorBrush(Color.FromRgb(64, 64, 64));
        }
        else
        {
            HotelBlock.BorderBrush = new SolidColorBrush(Colors.Red);
        }
    }

    private void Delete_OnClick(object sender, RoutedEventArgs e)
    {
        _deleteChanges.Invoke(_hotel);
    }

    private void Rooms_OnClick(object sender, RoutedEventArgs e)
    {
        _editRooms.Invoke(_hotel);
    }
}