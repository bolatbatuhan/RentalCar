﻿using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class RentalsController : ControllerBase
{
    IRentalService _rentalService;

    public RentalsController(IRentalService rentalService)
    {
        _rentalService = rentalService;
    }
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _rentalService.GetAll();
        if (result.Success)
        {
            return Ok(result.Data);
        }
        return BadRequest(result.Message);
    }
    [HttpPost("add")]
    public IActionResult Add(Rentals rental)
    {
        var result = _rentalService.Add(rental);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result.Message);
    }
    [HttpPost("delete")]
    public IActionResult Delete(Rentals rental)
    {
        var result = _rentalService.Delete(rental);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result.Message);
    }
    [HttpPost("update")]
    public IActionResult Update(Rentals rental)
    {
        var result = _rentalService.Update(rental);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result.Message);
    }
}
