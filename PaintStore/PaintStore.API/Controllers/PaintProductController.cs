using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PaintStore.API.Database;
using PaintStore.API.DTOs;
using PaintStore.Model;

namespace PaintStore.API.Controllers;


[Route("api/[controller]")]
[ApiController]
public class PaintProductController : ControllerBase
{
    private readonly PaintStoreDbContext _dbContext;
    public PaintProductController(PaintStoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // GET /api/paintProducts
    [HttpGet]
    public IActionResult GetAllPaints()
    {
        List<PaintProduct> paintProducts = _dbContext.PaintProducts.ToList();
        return Ok(paintProducts);
    }

    [HttpPost]
    public IActionResult CreatePaint([FromBody] PaintCreateDto paintProductDto)
    {
        PaintProduct paintProduct = new PaintProduct
        {
            Name = paintProductDto.Name,
            Price = paintProductDto.Price,
            PaintType = paintProductDto.PaintType
        };

        _dbContext.PaintProducts.Add(paintProduct);
        _dbContext.SaveChanges();

        PaintResponseDto paintResponse = ToPaintResponseDto(paintProduct);
        return Created($"/api/paintproduct/{paintResponse.Id}",paintResponse);
    }

    private static PaintResponseDto ToPaintResponseDto(PaintProduct paintProduct)
    {
        return new PaintResponseDto
        {
            Id = paintProduct.Id,
            Name = paintProduct.Name,
            PaintType = paintProduct.PaintType,
            Price = paintProduct.Price
        };
    }
}
