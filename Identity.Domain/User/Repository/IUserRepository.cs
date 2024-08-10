

 
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.User.Repository;

public interface IUserRepository
{
    Task<List<User>> GetAll();
    Task<User> GetById(Guid Id);
    Task<List<string>> GetRolesByUserId(Guid userId);
    Task<User> GetUser( string Country, string mobile); 
     
    Task Save(User user);
    Task Update(User user);
    Task Delete(User user);
}
