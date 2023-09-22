using System;
using System.Collections.Generic;
using System.Linq;
using ParadiseHotels.DAL.Entity;
using ParadiseHotels.DAL.Repositories;

namespace ParadiseUsers.Providers;

public class UserProvider
{
    private readonly IRepository<User> _userRepository;
    
    public UserProvider(IRepository<User> repository)
    {
        _userRepository = repository;
    }

    public void AddUsers(List<User> users)
    {
        foreach (var user in users)
        {
            AddUser(user);
        }
    }

    public void AddUser(User user) 
    {
        _userRepository.Add(user);
    }

    public User GetUserById(int id)
    {
        return _userRepository.Get(id);
    }

    public IEnumerable<User> GetUsers() 
    { 
        return  _userRepository.GetAll(); 
    }

    public void DeleteUserById(int id)
    {
        _userRepository.Remove(GetUserById(id));
    }
}