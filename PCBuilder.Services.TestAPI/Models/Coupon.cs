using System.ComponentModel.DataAnnotations;

namespace PCBuilder.Services.TestAPI.Models;

public class Coupon
{
    [Key]
    public int CouponId { get; set; }
    [Required]
    public string CouponCode { get; set; }
    [Required]
    public double Discount { get; set; }
    public int MinAmount { get; set; }
}
