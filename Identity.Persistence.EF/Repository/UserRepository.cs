


using Identity.Domain.User;
using Identity.Domain.User.Repository;
using Identity.Domain.User.ValueObjects;
using Identity.Persistence.EF.Context;

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Persistence.EF.Repository;

public class UserRepository : IUserRepository
{

    private readonly IdentityDbContext _dbContext;

    public UserRepository(IdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<User>> GetAll()
    {
        return await _dbContext.Users.ToListAsync();
    }

    public async Task<User> GetById(Guid Id)
    {
        return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == UserId.Create(Id));
    }

    public async Task<User> GetUser(string country, string mobile)
    {
        return await _dbContext.Users.AsNoTracking()
            .SingleOrDefaultAsync(x => x.Mobile.Country == country && x.Mobile.Number == mobile);
    }

    public async Task<List<string>> GetRolesByUserId(Guid userId)
    {
        var _user = await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == UserId.Create(userId));
        if (_user is not null)
        {
            List<string> list = (from ur in _user.UserRoles
                                 join r in _dbContext.Roles on ur.RoleId equals r.Id
                                 select r.Name).ToList<string>();
            return list;
        }
        return new List<string>();
    }
    public async Task Save(User user)
    {
        await _dbContext.Users.AddAsync(user);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(User user)
    {
        _dbContext.Update(user);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Delete(User user)
    {
        _dbContext.Remove(user);
        await _dbContext.SaveChangesAsync();
    }



}
