using System;
using System.Collections.Generic;
using System.Linq;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.DAL.Repositories;

namespace ParadiseRoomsStatus.Providers;

public class RoomBookingProvider
{
    private readonly IRepository<RoomBooking> _statusRepository;
    
    public RoomBookingProvider(IRepository<RoomBooking> repository)
    {
        _statusRepository = repository;
    }

    public void AddRoomBookings(List<RoomBooking> statuses)
    {
        foreach (var status in statuses)
        {
            AddRoomBooking(status);
        }
    }

    public void AddRoomBooking(RoomBooking status) 
    {
        _statusRepository.Add(status);
    }

    public RoomBooking GetRoomBookingById(int id)
    {
        return _statusRepository.Get(id);
    }

    public IEnumerable<RoomBooking> GetRoomBookings() 
    { 
        return  _statusRepository.GetAll(); 
    }

    public void DeleteRoomBookingById(int id)
    {
        _statusRepository.Remove(GetRoomBookingById(id));
    }
}