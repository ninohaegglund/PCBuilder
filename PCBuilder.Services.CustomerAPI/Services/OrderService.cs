using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PCBuilder.Service.BuilderServiceAPI.Enums;
using PCBuilder.Services.CustomerAPI.DTO;
using PCBuilder.Services.CustomerAPI.IRepositories;
using PCBuilder.Services.CustomerAPI.IRepository;
using PCBuilder.Services.CustomerAPI.IServices;
using PCBuilder.Services.CustomerAPI.Repositories;
using PCBuilder.Services.CustomerAPI.Response;
using System;

namespace PCBuilder.Services.CustomerAPI.Services;

public class OrderService : IOrderService
{

    private readonly IMapper _mapper;
    private readonly IOrderRepository _orderRepository;

    public OrderService(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }
    public async Task<ResponseDTO> GetAllOrdersAsync()
    {
        try
        {
            var orders = await _orderRepository.GetAllOrders();
            var orderDTOs = _mapper.Map<List<OrderDTO>>(orders);

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
    public  async Task<ResponseDTO> GetOrderByIdAsync(int id)
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

            var orderDTO = _mapper.Map<OrderDTO>(order);

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
    public Task<ResponseDTO> AcceptOrder(int orderId)
    {
        //- Hämta en order,
        //- kontrollera att den finns kolla så att den är pending
        //- skapa en computer via API
        //- Få tillbaka nytt computerId,
        //- uppdatera ordern status till inprogress och spara computerId i ordern,

        throw new NotImplementedException();
    }
    public Task<ResponseDTO> RejectOrder(int orderId)
    {

        //hämta ordern
        //kontrollera att den finns
        //kanske kontrollera att den inte redan är klar
        //sätta Status = Cancelled
        //spara


        throw new NotImplementedException();
    }
    public Task<ResponseDTO> CompleteOrder(int orderId)
    {
        // hämta ordern
        // kontrollera att den finns
        // kontrollera att den är InProgress
        // sätta Status = Completed
        // spara
        throw new NotImplementedException();
    }
}
