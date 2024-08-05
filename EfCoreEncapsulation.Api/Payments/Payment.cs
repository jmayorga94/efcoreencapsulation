using EfCoreEncapsulation.Api.Members;

namespace EfCoreEncapsulation.Api.Payments;

public class Payment
{
    public int PaymentId { get; set; }
    public int MemberId { get; set; }
    public decimal Amount { get; set; }
    public DateTime PaymentDate { get; set; }

    public Member Member { get; set; }
}
