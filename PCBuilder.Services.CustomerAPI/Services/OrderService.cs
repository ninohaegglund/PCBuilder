using AutoMapper;
using PCBuilder.Service.BuilderServiceAPI.Enums;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Response;
using System;

namespace PCBuilder.Services.CustomerAPI.Services;

public class OrderService : IOrderService
{

    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerRepository _customerRepository;

    public OrderService(IOrderRepository orderRepository, ICustomerRepository customerRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _customerRepository = customerRepository;
        _mapper = mapper;
    }
    public async Task<ResponseDTO> GetAllOrdersAsync()
    {
        try
        {
            var orders = await _orderRepository.GetAllOrders();
            var orderDTOs = new List<OrderListDTO>();

            foreach (var order in orders)
            {
                var customer = await _customerRepository.GetCustomerById(order.CustomerId);

                var dto = new OrderListDTO
                {
                    Id = order.Id,
                    CustomerId = order.CustomerId,
                    CustomerName = customer?.Name ?? "Unknown customer",
                    CustomerImageUrl = customer?.ImageUrl ?? string.Empty,
                    ComputerId = order.ComputerId,
                    Budget = order.Budget,
                    Description = order.Description,
                    DetailedDescription = order.DetailedDescription,
                    Status = (OrderStatus)order.Status,
                    CreatedAt = order.CreatedAt
                };

                orderDTOs.Add(dto);
            }

            return new ResponseDTO
            {
                IsSuccess = true,
                Result = orderDTOs
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
    public async Task<ResponseDTO> GetOrderByIdAsync(int id)
    {
        try
        {
            var order = await _orderRepository.GetOrderById(id);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {id} not found."
                };
            }

            var customer = await _customerRepository.GetCustomerById(order.CustomerId);

            var orderDTO = new OrderListDTO
            {
                Id = order.Id,
                CustomerId = order.CustomerId,
                CustomerName = customer?.Name ?? "Unknown customer",
                CustomerImageUrl = customer?.ImageUrl ?? string.Empty,
                ComputerId = order.ComputerId,
                Budget = order.Budget,
                Description = order.Description,
                DetailedDescription = order.DetailedDescription,
                Status = (OrderStatus)order.Status,
                CreatedAt = order.CreatedAt
            };

            return new ResponseDTO
            {
                IsSuccess = true,
                Result = orderDTO
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
    public async Task<ResponseDTO> AcceptOrderAsync(int orderId)
    {
        try
        {
            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {orderId} not found."
                };
            }

            if (order.Status != Models.OrderStatus.Pending)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Only pending orders can be accepted."
                };
            }

            order.Status = Models.OrderStatus.InProgress;
            await _orderRepository.UpdateOrder(order);

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Order accepted successfully.",
                Result = order
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
    public async Task<ResponseDTO> RejectOrderAsync(int orderId)
    {
        try
        {
            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {orderId} not found."
                };
            }

            if (order.Status == Models.OrderStatus.Completed)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Completed orders cannot be rejected."
                };
            }

            order.Status = Models.OrderStatus.Rejected;
            await _orderRepository.UpdateOrder(order);

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Order rejected successfully.",
                Result = order
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
    public async Task<ResponseDTO> CompleteOrderAsync(int orderId)
    {
        try
        {
            var order = await _orderRepository.GetOrderById(orderId);

            if (order == null)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = $"Order with id {orderId} not found."
                };
            }

            if (order.Status != Models.OrderStatus.InProgress)
            {
                return new ResponseDTO
                {
                    IsSuccess = false,
                    Message = "Only in-progress orders can be completed."
                };
            }

            order.Status = Models.OrderStatus.Completed;
            await _orderRepository.UpdateOrder(order);

            return new ResponseDTO
            {
                IsSuccess = true,
                Message = "Order completed successfully.",
                Result = order
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
