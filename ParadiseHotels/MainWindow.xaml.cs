using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Services;

namespace ParadiseHotels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private SelectRoomPage _selectRoomPage = new SelectRoomPage();
        private Services.Services _services = new Services.Services();
        
        public MainWindow()
        {
            InitializeComponent();

            _selectRoomPage.onRoomClick += Room_OnMouseLeftButtonUp;
            
            Frame.Navigate(_selectRoomPage);
            
            // TEST DATA
            // _services.uploadTestData();
        }
        
        private void Room_OnMouseLeftButtonUp(object sender, EventArgs e)
        {
            Frame.Navigate(new BookRoomPage(RoomBookingBack_OnMouseLeftButtonUp));
        }

        private void RoomBookingBack_OnMouseLeftButtonUp(object sender, EventArgs e)
        {
            Frame.Navigate(_selectRoomPage);
        }
    }
}