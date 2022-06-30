namespace Application.Dtos.Request;

using System.ComponentModel.DataAnnotations;

public class GetBillRequestDto
{
    [Required]
    public string ProductSku { get; set; }
    [Required]
    public string UserId { get; set; }
}