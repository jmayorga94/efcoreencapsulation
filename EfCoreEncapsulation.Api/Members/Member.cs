using EfCoreEncapsulation.Api.Enrollments;

namespace EfCoreEncapsulation.Api.Members;

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public DateTime MembershipStartDate { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
}
