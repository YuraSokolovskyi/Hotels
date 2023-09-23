using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ParadiseHotels.Controls;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Pages;

public partial class EditHotelsPage : Page
{
    public delegate void BackToHotels();
    public delegate void EditRoomsDelegate(Hotel hotel);
    
    private Services.Services _services;
    private BackToHotels _backToHotels;
    private EditRoomsDelegate _editRooms;
    
    public EditHotelsPage(Services.Services services, BackToHotels backToHotels, EditRoomsDelegate editRooms)
    {
        InitializeComponent();

        _backToHotels = backToHotels;
        _editRooms = editRooms;
        _services = services;
        
        createHotels();
    }

    private void createHotels()
    {
        foreach (Hotel hotel in _services.getHotels())
        {
            createHotel(hotel);
        }
    }

    private void createHotel(Hotel hotel)
    {
        Hotels.Children.Add(new EditHotelComponent(hotel, saveChanges, deleteHotel, editRooms));
    }

    private void ImageBackMouseUp(object sender, MouseButtonEventArgs e)
    {
        _backToHotels.Invoke();
    }

    private bool saveChanges(Hotel hotel)
    {
        return _services.updateHotel(hotel);
    }
    
    private void deleteHotel(Hotel hotel)
    {
        _services.deleteHotel(hotel);
        Hotels.Children.Clear();
        createHotels();
    }

    private void editRooms(Hotel hotel)
    {
        _editRooms.Invoke(hotel);
    }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        Hotels.Children.Add(new EditHotelComponent(new Hotel(), saveChanges, deleteHotel, editRooms));
    }
}