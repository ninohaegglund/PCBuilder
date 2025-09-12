﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PCBuilder.Web.Models.Dto;
using PCBuilder.Web.Service.IService;

namespace PCBuilder.Web.Controllers;

public class CouponController : Controller
{

    private readonly ICouponService _couponService;
    public CouponController(ICouponService couponService)
    {
        _couponService = couponService;
    }

    public async Task<IActionResult> CouponIndex()
    {
        List<CouponDto>? list = new();

        ResponseDto? response = await _couponService.GetAllCouponsAsync();

        if(response != null && response.IsSuccess)
        {
            list = JsonConvert.DeserializeObject<List<CouponDto>>(Convert.ToString(response.Result));
        }

        return View(list);
    }
}
