using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ParadiseHotels;

public partial class BookRoomPage : Page
{
    private MouseButtonEventHandler _backEvent;
    
    public BookRoomPage()
    {
        InitializeComponent();
    }
    
    public BookRoomPage(MouseButtonEventHandler backEvent)
    {
        InitializeComponent();

        _backEvent = backEvent;

        NavigationBlockBack.MouseLeftButtonUp += NavigationBlockBack_OnMouseLeftButtonUp;
    }

    private void NavigationBlockBack_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
    {
        _backEvent?.Invoke(sender, e);
    }
}