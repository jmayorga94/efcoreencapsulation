using EfCoreEncapsulation.Api.Infrastructure.Persistence;
using EfCoreEncapsulation.Api.Members;
using Microsoft.EntityFrameworkCore;

namespace EfCoreEncapsulation.Api.Infrastructure.Repositories;

public class MembersRepository
{
    private GymContext _context;
    public MembersRepository(GymContext context)
    {
        _context = context;
    }

    public Member? GetMemberById(int id)
    {
       return _context.Members
          .SingleOrDefault(m => m.MemberId == id);
    }
}
