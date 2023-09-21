using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace ParadiseHotels;

public partial class SelectRoomPage : Page
{
    public event MouseButtonEventHandler onRoomClick;
    
    public SelectRoomPage()
    {
        InitializeComponent();
        
        createRoom();
        createRoom();
        createRoom();
        createRoom();
        createRoom();
        createRoom();
        createRoom();
        createRoom();
        createRoom();
        createRoom();
        createRoom();
    }
    
    void createRoom()
    {
        Room room = new Room(new RoomData() { Name = "The Aston Vill Room", Address = "Alice Springs NT 0870, Australia", Description = "Test_description" });
        room.MouseUp += RoomClick;
            
        Rooms.Children.Add(room);
    }

    private void RoomClick(object sender, MouseButtonEventArgs e)
    {
        onRoomClick?.Invoke(this, e);
    }
}