using EfCoreEncapsulation.Api.Classes;
using EfCoreEncapsulation.Api.Infrastructure.Persistence;
using EfCoreEncapsulation.Api.Members;

namespace EfCoreEncapsulation.Api.Infrastructure.Repositories
{
    public class ClassesRepository
    {
        private GymContext _context;
        public ClassesRepository(GymContext context)
        {
            _context = context;
        }

        public Class? GetClassById(int id)
        {
            return _context.Classes
               .SingleOrDefault(m => m.Id == id);
        }
    }
}
