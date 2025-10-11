using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using PCBuilder.Service.BuilderServiceAPI.Models.DTO.Response;

namespace PCBuilder.Service.BuilderServiceAPI.IService
{
    public interface IBuilderBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDto);
    }
}