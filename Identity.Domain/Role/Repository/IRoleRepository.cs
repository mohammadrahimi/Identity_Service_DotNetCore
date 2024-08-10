

using Identity.Domain.Role.Enum;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Domain.Role.Repository;

public interface IRoleRepository
{
    Task<List<Role>> GetAll();
    Task<Role> GetById(Guid Id);
    Task<Role> GetByName(EnumeRole enumRole);
    Task Save(Role role);
    Task Update(Role role);
    Task Delete(Role role);
}
