using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels;

public partial class SelectHotelPage : Page
{
    public delegate void SetFiltersDelegate(DateTime startDate, DateTime endDate, int minPrice, int maxPrice);

    public delegate void ShowBookings();
    
    public event MouseButtonEventHandler _onHotelClick;
    public ShowBookings _showBookings;
    private Services.Services _services;

    // filters
    private SetFiltersDelegate _setFilters;
    private DateTime _startDate;
    private DateTime _endDate;
    private int _minPrice;
    private int _maxPrice;

    private bool _maxPriceLoaded = false;
    
    public SelectHotelPage(
        Services.Services services, 
        DateTime startDate, 
        DateTime endDate, 
        int minPrice, 
        int maxPrice, 
        SetFiltersDelegate setFilters,
        ShowBookings showBookings)
    {
        InitializeComponent();

        _services = services;
        _showBookings = showBookings;
        
        // filters
        _setFilters = setFilters;
        _startDate = startDate;
        _endDate = endDate;
        _minPrice = minPrice;
        _maxPrice = maxPrice;
        
        

        setDefaultFilters();
        
        createHotels();
    }

    private void setDefaultFilters()
    {
        StartDate.SelectedDate = _startDate;
        EndDate.SelectedDate = _endDate;
        
        MinPrice.Text = _minPrice.ToString();
        MaxPrice.Text = _maxPrice == -1 ? "" : _maxPrice.ToString();
    }
    
    private void CreateHotel(Hotel hotel)
    {
        HotelComponent hotelComponent = new HotelComponent(hotel);
        hotelComponent.MouseUp += HotelClick;
            
        Hotels.Children.Add(hotelComponent);
    }

    private void createHotels()
    {
        foreach (Hotel hotel in Services.Services.getHotelsWithFreeRooms(_services.getHotels(), _startDate, _endDate))
        {
            if (Services.Services.isHotelAffordable(hotel, _minPrice, _maxPrice) || _maxPrice == -1) 
                CreateHotel(hotel);
        }
    }

    private void HotelClick(object sender, MouseButtonEventArgs e)
    {
        _onHotelClick?.Invoke(sender, e);
    }

    private void filtersChanged()
    {
        _setFilters(_startDate, _endDate, _minPrice, _maxPrice);
    }

    private void StartDate_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        DateTime start = StartDate.SelectedDate.Value;
        if (start != _startDate)
        {
            _startDate = start;
            if (start >= _endDate) _endDate = start.AddDays(1);
            filtersChanged();
        }
        
    }

    private void EndDate_OnSelectedDateChanged(object? sender, SelectionChangedEventArgs e)
    {
        DateTime end = EndDate.SelectedDate.Value;
        if (end != _endDate)
        {
            _endDate = end;
            if (end <= _startDate) _startDate = end.AddDays(-1);
            filtersChanged();
        }
    }

    private void MinPrice_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        if (!_maxPriceLoaded) return;
        
        int max = -1;
        int min = 0;
        
        if (MaxPrice.Text == "") max = -1;
        else max = Int32.Parse(MaxPrice.Text);

        if (MinPrice.Text == "") min = 0;
        else min = Int32.Parse(MinPrice.Text);

        if (min > max) max = min;

        _minPrice = min;
        _maxPrice = max;
    }

    private void MaxPrice_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        int max = -1;
        int min = 0;
        
        if (MaxPrice.Text == "") max = -1;
        else max = Int32.Parse(MaxPrice.Text);

        if (MinPrice.Text == "") min = 0;
        else min = Int32.Parse(MinPrice.Text);

        if (min > max && max != -1) min = max;

        _minPrice = min;
        _maxPrice = max;
    }

    private void MaxPrice_OnLoaded(object sender, RoutedEventArgs e)
    {
        _maxPriceLoaded = true;
    }

    private void Price_OnPreviewTextInput(object sender, TextCompositionEventArgs e)
    {
        Regex regex = new Regex("[^0-9]+");
        e.Handled = regex.IsMatch(e.Text);
    }

    private void Price_OnKeyDown(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter) filtersChanged();
    }

    private void Bookings_OnMouseUp(object sender, MouseButtonEventArgs e)
    {
        _showBookings.Invoke();
    }
}