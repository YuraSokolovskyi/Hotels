using System;
using System.Collections.Generic;
using System.Linq;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.DAL.Repositories;

namespace ParadiseHotels.Providers;

public class HotelProvider
{
    private readonly IRepository<Hotel> _hotelRepository;
    
    public HotelProvider(IRepository<Hotel> repository)
    {
        _hotelRepository = repository;
    }

    public void AddHotels(List<Hotel> hotels)
    {
        foreach (var hotel in hotels)
        {
            AddHotel(hotel);
        }
    }

    public void AddHotel(Hotel hotel) 
    {
        _hotelRepository.Add(hotel);
    }

    public Hotel GetHotelById(int id)
    {
        return _hotelRepository.Get(id);
    }

    public IEnumerable<Hotel> GetHotels() 
    { 
        return  _hotelRepository.GetAll(); 
    }

    public void DeleteHotelById(int id)
    {
        _hotelRepository.Remove(GetHotelById(id));
    }

    public void UpdateHotel(Hotel hotel)
    {
        _hotelRepository.Update(hotel);
    }
}