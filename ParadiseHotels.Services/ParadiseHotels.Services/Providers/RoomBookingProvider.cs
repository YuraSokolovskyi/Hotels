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

    public void AddRoomsStatuses(List<RoomBooking> statuses)
    {
        foreach (var status in statuses)
        {
            AddRoomsStatus(status);
        }
    }

    public void AddRoomsStatus(RoomBooking status) 
    {
        _statusRepository.Add(status);
    }

    public RoomBooking GetRoomsStatusById(int id)
    {
        return _statusRepository.Get(id);
    }

    public IEnumerable<RoomBooking> GetRoomsStatuses() 
    { 
        return  _statusRepository.GetAll(); 
    }

    public void DeleteRoomsStatusById(int id)
    {
        _statusRepository.Remove(GetRoomsStatusById(id));
    }
}