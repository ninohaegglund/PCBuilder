using PCBuilder.Service.BuilderServiceAPI.DTO.Response;
using Contracts;

namespace PCBuilder.Service.BuilderServiceAPI.IService
{
    public interface IBuilderBaseService
    {
        Task<ResponseDTO?> SendAsync(RequestDTO requestDto);
    }
}