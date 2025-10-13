using AutoMapper;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;

namespace PCBuilder.Services.CustomerAPI.Services;

public class CustomerService : ICustomerService
{
    private readonly IMapper _mapper;
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository, IMapper mapper)
    {
        _customerRepository = customerRepository;
        _mapper = mapper;
    }

    public async Task<ResponseDTO> GetAllCustomersAsync()
    {
        try
        {
            var customers = await _customerRepository.GetAllCustomers();
            var customerDTOs = _mapper.Map<List<CustomerDTO>>(customers);

            return new ResponseDTO
            {
                IsSuccess = true,
                Result = customerDTOs
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }

    public async Task<ResponseDTO> GetCustomerByIdAsync(int id)
    {
        try
        {
            var customer = await _customerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Customer with id {id} not found."
                };
            }

            var customerDTO = _mapper.Map<CustomerDTO>(customer);

            return new ResponseDTO
            {
                IsSuccess = true,
                Result = customerDTO
            };
        }
        catch (Exception ex)
        {
            return new ResponseDTO
            {
                IsSuccess = false,
                Message = ex.Message
            };
        }
    }
}
