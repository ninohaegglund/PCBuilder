using PCBuilder.Web.Models.Dto;

namespace PCBuilder.Web.Service.IService;

public interface IBaseService
{
    Task<ResponseDto?> SendAsync(RequestDto requestDto);
}
