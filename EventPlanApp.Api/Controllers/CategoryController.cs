using AutoMapper;
using EventPlanApp.Application.DTOs;
using EventPlanApp.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EventPlanApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<IActionResult> GetCategories()
    {
        try
        {
            var categories = await _categoryService.GetAll();
            return Ok(categories);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = ex.Message });
        }
    }
}
