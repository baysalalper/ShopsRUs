namespace Application.Dtos.Response;

public class GetBillResponseDto
{
    public ProductObj Product { get; set; }
    public CustomerInfoObj CustomerInfo { get; set; }
}

public class ProductObj
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal DiscountedPrice { get; set; }
}

public class CustomerInfoObj
{
    public string CustomerName { get; set; }
    public string Address { get; set; }
}