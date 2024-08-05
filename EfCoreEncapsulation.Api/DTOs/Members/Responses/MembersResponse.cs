namespace EfCoreEncapsulation.Api.DTOs.Members.Responses
{
    public record MembersResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime MemberSince { get; set; }
        public IReadOnlyList<EnrollmentsResponse> Classes { get; set; }
        public IReadOnlyList<PaymentResponse> Payments { get; set; }
        public bool IsUpToDate { get; set; }


    }

    public record EnrollmentsResponse
    {
        public string ClassName { get; set; }
        public string Instructor { get; set; }
    }


    public record PaymentResponse
    {
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
