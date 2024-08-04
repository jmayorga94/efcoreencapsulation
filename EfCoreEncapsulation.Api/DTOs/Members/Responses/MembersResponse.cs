namespace EfCoreEncapsulation.Api.DTOs.Members.Responses
{
    public record MembersResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MemberSince { get; set; }
    }
}
