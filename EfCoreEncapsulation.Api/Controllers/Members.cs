using EfCoreEncapsulation.Api.DTOs.Members.Responses;
using EfCoreEncapsulation.Api.Infrastructure.Persistence;
using EfCoreEncapsulation.Api.Members;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EfCoreEncapsulation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Members : ControllerBase
    {
        private readonly GymContext _context;
        public Members(GymContext context)
        {
            _context = context;
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var result =  _context.Members.Find(id);

            if(result is null)
            {
                return NotFound();
            }

            var response = new MembersResponse()
            {
                Id = result.MemberId,
                MemberSince = result.MembershipStartDate,
                Name = result.Name,
            };

            return Ok(response);

        }
    }
}
