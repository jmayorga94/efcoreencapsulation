using EfCoreEncapsulation.Api.Classes;
using EfCoreEncapsulation.Api.Members;

namespace EfCoreEncapsulation.Api.Enrollments;

public class Enrollment
{
    public int MemberId { get; set; }
    public Member Member { get; set; }
    public int ClassId { get; set; }
    public Class Class { get; set; }
}
