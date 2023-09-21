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
using Newtonsoft.Json;
using ParadiseHotels.DAL;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.Providers;
using ParadiseHotels.DAL.Repositories;

namespace ParadiseHotels
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private SelectRoomPage _selectRoomPage = new SelectRoomPage();
        
        public MainWindow()
        {
            InitializeComponent();

            _selectRoomPage.onRoomClick += Room_OnMouseLeftButtonUp;
            
            Frame.Navigate(_selectRoomPage);
            
            // TEST DATA
            uploadTestData();
        }

        private void uploadTestData()
        {
            string jsonPath = "D:\\C#\\Hotels\\ParadiseHotels\\TestData\\RoomsData.json";
            string content = File.ReadAllText(jsonPath);
            
            var context = new ParadiseHotelsContext();

            var hotelRepository = new Repository<Hotel>(context);
            var hotelProvider = new HotelProvider(hotelRepository);

            // var roomRepository = new Repository<ParadiseHotels.DAL.Entity.Room>(context);
            // var roomProvider = new RoomProvider(roomRepository);
            List<Hotel> res = JsonConvert.DeserializeObject<List<Hotel>>(content);
            hotelProvider.AddHotels(res);
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