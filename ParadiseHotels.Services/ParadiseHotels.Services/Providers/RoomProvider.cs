using System;
using System.Collections.Generic;
using System.Linq;
using ParadiseHotels.DAL.Repositories;
using ParadiseHotels.DAL.Entity;

namespace ParadiseHotels.Providers;

public class RoomProvider
{
    private readonly IRepository<Room> _roomRepository;
    
    public RoomProvider(IRepository<Room> repository)
    {
        _roomRepository = repository;
    }

    public void AddRooms(List<Room> rooms)
    {
        foreach (var room in rooms)
        {
            AddRoom(room);
        }
    }

    public void AddRoom(Room room) 
    {
        _roomRepository.Add(room);
    }

    public void AddBooking(Room room, DateTime startDate, DateTime endDate, int userId)
    {
        if (room.RoomBooking == null) room.RoomBooking = new List<RoomBooking>();
        room.RoomBooking.Add(new RoomBooking() {BookingStart = startDate, BookingEnd = endDate, UserId = userId});
        _roomRepository.Update(room);
    }

    public Room GetRoomById(int id)
    {
        return _roomRepository.Get(id);
    }

    public IEnumerable<Room> GetRooms() 
    { 
        return  _roomRepository.GetAll(); 
    }

    public void DeleteRoomById(int id)
    {
        _roomRepository.Remove(GetRoomById(id));
    }
}