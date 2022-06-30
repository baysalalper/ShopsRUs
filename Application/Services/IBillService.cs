namespace Application.Services;

using Dtos.Request;
using Dtos.Response;

public interface IBillService
{
    Task<GetBillResponseDto> GetBill(GetBillRequestDto request);
}