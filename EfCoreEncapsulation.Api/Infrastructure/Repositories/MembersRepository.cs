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

    public Member? GetMemberByIdWithSplitQuery(int id)
    {
        /*
         * This will help improve performance since entity framework is spliting retrieving info from Enrrollments
         * and payments
         */
        return _context.Members
           .Include(m => m.Enrollments)
           .ThenInclude(e=> e.Class)
           .Include(m=> m.Payments)
           .AsSplitQuery()
           .SingleOrDefault(m=> m.MemberId == id);
    }

    public Member? GetMemberByIdWithLoadingCollections(int id)
    {
        /*
         * This is another example when dealing with product cartasian. In this we are going to explicitly load our entities
         * and payments
         */
        var member = _context.Members
               .SingleOrDefault(m => m.MemberId == id);

        if (member is null)
        {
            return null;
        }

        _context.Entry(member).Collection(member=> member.Payments).Load();
        _context.Entry(member).Collection(member => member.Enrollments).Load();

        return member;


    }
}
