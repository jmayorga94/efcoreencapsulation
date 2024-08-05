using EfCoreEncapsulation.Api.DTOs.Members.Responses;
using EfCoreEncapsulation.Api.Infrastructure.Persistence;
using EfCoreEncapsulation.Api.Infrastructure.Repositories;
using EfCoreEncapsulation.Api.Members;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EfCoreEncapsulation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Members : ControllerBase
    {
        private readonly MembersRepository _repository;
        public Members(MembersRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetMemberById(id);

            if (result is null)
            {
                return NotFound();
            }

            var response = new MembersResponse()
            {
                Id = result.MemberId,
                MemberSince = result.MembershipStartDate,
                Name = result.Name,
                Classes = result.Enrollments.Select(enrollment => new EnrollmentsResponse()
                {
                    ClassName = enrollment.Class.ClassName,
                    Instructor = enrollment.Class.Instructor
                }).ToList()
            };

            return Ok(response);

        }
    }
}
