using EfCoreEncapsulation.Api.DTOs.Members.Responses;
using EfCoreEncapsulation.Api.Infrastructure.Persistence;
using EfCoreEncapsulation.Api.Infrastructure.Repositories;
using EfCoreEncapsulation.Api.Members;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace EfCoreEncapsulation.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Members : ControllerBase
    {
        private readonly MembersRepository _repository;
        private readonly ClassesRepository _classesRepository;
        public Members(MembersRepository repository,
                       ClassesRepository classesRepository)
        {
            _repository = repository;
            _classesRepository = classesRepository;
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            var result = _repository.GetMemberByIdWithLoadingCollections(id);

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
                }).ToList(),
                Payments = result.Payments.Select(p => new PaymentResponse()
                {
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate
                }).ToList()
            };

            if (result.Payments.Any(p => p.PaymentDate.Month == DateTime.Now.Month
                                        && p.PaymentDate.Year == DateTime.Now.Year))
            {
                response.IsUpToDate = true;
            };

            return Ok(response);
        }

        [HttpPost]
        public IActionResult Enroll(int memberId,int classId)
        {
            /*
             * Partially initialized antipattern
             * This happens when you only retrieve a part of your entity and want to enforce invariants on it
             * This is antipattern because it breaches encapsulation
             */
            var member = _repository.GetMemberById(memberId);

            if(member is null)
                return NotFound($"Member with id {memberId} could not be found");
            var classToRegister = _classesRepository.GetClassById(classId);

            if (classToRegister is null)
            {
                return NotFound($"Class with id {classId} could not be found");
            }
            
            var result = member.Enroll(classToRegister);

            if (result != "ok")
                return Problem(statusCode: StatusCodes.Status500InternalServerError, title:"Error while creating member");

            return Ok(result);

        }
    }
}
