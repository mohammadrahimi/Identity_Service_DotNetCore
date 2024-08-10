


using Identity.Domain.Role;
using Identity.Domain.Role.Enum;
using Identity.Domain.Role.Repository;
using Identity.Domain.Role.ValueObjects;
using Identity.Persistence.EF.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Identity.Persistence.EF.Repository;

public class RoleRepository : IRoleRepository
{
    private readonly IdentityDbContext _dbContext;

    public RoleRepository(IdentityDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<Role>> GetAll()
    {
        return await _dbContext.Roles.ToListAsync();
    }
    public async Task<Role> GetByName(EnumeRole enumRole)
    {
        return await _dbContext.Roles.SingleOrDefaultAsync(x => x.Name ==  enumRole.ToString());
    }

    public async Task<Role> GetById(Guid Id)
    {
        return await _dbContext.Roles.SingleOrDefaultAsync(x => x.Id == RoleId.Create(Id));

    }

    public async Task Save(Role role)
    {
        await _dbContext.Roles.AddAsync(role);
        await _dbContext.SaveChangesAsync();
    }

    public async Task Update(Role role)
    {
        _dbContext.Update(role);
        await _dbContext.SaveChangesAsync();
    }
    public async Task Delete(Role role)
    {
        _dbContext.Remove(role);
        await _dbContext.SaveChangesAsync();
    }

   
}
