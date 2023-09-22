using System;
using System.Collections.Generic;
using System.Linq;
using ParadiseHotels.DAL.Repositories;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Providers;

public class RoomProvider
{
    private readonly IRepository<ParadiseHotels.DAL.Entity.Room> _roomRepository;
    
    public RoomProvider(IRepository<ParadiseHotels.DAL.Entity.Room> repository)
    {
        _roomRepository = repository;
    }

    public void AddRooms(List<ParadiseHotels.DAL.Entity.Room> rooms)
    {
        foreach (var room in rooms)
        {
            AddRoom(room);
        }
    }

    public void AddRoom(ParadiseHotels.DAL.Entity.Room room) 
    {
        _roomRepository.Add(room);
    }

    public ParadiseHotels.DAL.Entity.Room GetRoomById(int id)
    {
        return _roomRepository.Get(id);
    }

    public IEnumerable<ParadiseHotels.DAL.Entity.Room> GetRooms() 
    { 
        return  _roomRepository.GetAll(); 
    }

    public void DeleteRoomById(int id)
    {
        _roomRepository.Remove(GetRoomById(id));
    }
}