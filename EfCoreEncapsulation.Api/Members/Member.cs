
using EfCoreEncapsulation.Api.Classes;
using EfCoreEncapsulation.Api.Enrollments;
using EfCoreEncapsulation.Api.Payments;

namespace EfCoreEncapsulation.Api.Members;

public class Member
{
    public int MemberId { get; set; }
    public string Name { get; set; }
    public DateTime MembershipStartDate { get; set; }

    public ICollection<Enrollment> Enrollments { get; set; }
    public ICollection<Payment> Payments { get; set; }

    public string Enroll(Class classToRegister)
    {
        if (Enrollments.Any(e => e.Class == classToRegister))
            return $"Already enrolled {classToRegister.ClassName}";

        var enrollment = new Enrollment()
        {
            Class = classToRegister
        };

        Enrollments.Add(enrollment);

        return "ok";
    }
}
