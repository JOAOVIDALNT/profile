using profile.Domain.Entities;
using profile.Domain.Interfaces.Repositories;
using valet.lib.Core.Data.Repositories;

namespace profile.Infrastructure.Data.Repositories;

public class LocalUserRepository(AppDbContext db) : Repository<LocalUser>(db), ILocalUserRepository
{
    
}