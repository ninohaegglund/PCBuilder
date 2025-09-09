namespace PCBuilder.Web.Models.Dto;

public class CouponDto
{
    public int CouponId { get; set; }
    public string CouponCode { get; set; } = null!;
    public double Discount { get; set; }
    public int MinAmount { get; set; }
}
