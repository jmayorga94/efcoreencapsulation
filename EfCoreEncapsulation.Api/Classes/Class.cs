using EfCoreEncapsulation.Api.Enrollments;

namespace EfCoreEncapsulation.Api.Classes;

public class Class
{
    public int Id { get; set; }
    public string ClassName { get; set; }
    public string Instructor { get; set; }
    public ICollection<Enrollment> Enrollments { get; set; }
}
