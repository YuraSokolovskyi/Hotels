using System;
using System.Collections.Generic;
using System.Linq;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.DAL.Repositories;

namespace ParadiseRoomsStatus.Providers;

public class RoomsStatusProvider
{
    private readonly IRepository<RoomsStatus> _statusRepository;
    
    public RoomsStatusProvider(IRepository<RoomsStatus> repository)
    {
        _statusRepository = repository;
    }

    public void AddRoomsStatuses(List<RoomsStatus> statuses)
    {
        foreach (var status in statuses)
        {
            AddRoomsStatus(status);
        }
    }

    public void AddRoomsStatus(RoomsStatus status) 
    {
        _statusRepository.Add(status);
    }

    public RoomsStatus GetRoomsStatusById(int id)
    {
        return _statusRepository.Get(id);
    }

    public IEnumerable<RoomsStatus> GetRoomsStatuses() 
    { 
        return  _statusRepository.GetAll(); 
    }

    public void DeleteRoomsStatusById(int id)
    {
        _statusRepository.Remove(GetRoomsStatusById(id));
    }
}