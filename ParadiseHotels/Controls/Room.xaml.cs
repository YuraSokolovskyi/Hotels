using System.Windows.Controls;
using System.Windows.Data;

namespace ParadiseHotels;

public class RoomData
{
    public string Name { get; set; }
    public string Address { get; set; }
    public string Description { get; set; }
}

public partial class Room : UserControl
{
    public RoomData RoomData { get; set; }
    
    public Room()
    {
        InitializeComponent();
    }
    
    public Room(RoomData roomData)
    {
        InitializeComponent();
        setData(roomData);
    }

    public void setData(RoomData roomData)
    {
        RoomData = roomData;

        RoomName.Text = RoomData.Name;
        RoomAddress.Text = RoomData.Address;
        RoomDescription.Text = RoomData.Description;
    }
}