using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LILAPICourse.Data;
using LILAPICourse.Data.Entities;
using LILAPICourse.Model;

namespace LILAPICourse.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PriceHistoryController : ControllerBase
    {
        private readonly StoreDBContext _context;

        public PriceHistoryController(StoreDBContext context)
        {
            _context = context;
        }

        // GET: api/PriceHistory/Product/Guid
        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<PriceHistoryViewModel>>> GetRankHistory([FromRoute]Guid productId)
        {
            return await _context.PriceHistory.Where(z=>z.ProductId== productId).Select(price=>new PriceHistoryViewModel
            { 
             Id=price.Id,
             NewPrice=price.NewPrice,
             ChangeDate=price.ChangeDate, 
             ProductId=price.ProductId,
             ProductName=price.Product.Name
            }).OrderByDescending(z=>z.ChangeDate).ToListAsync();
        }

        [HttpGet("v2/product/{productId}")]
        public async Task<ActionResult<IEnumerable<PriceHistoryViewModelV2>>> GetRankHistoryV2([FromRoute] Guid productId)
        {
            return await _context.PriceHistory.Where(z => z.ProductId == productId).Select(price => new PriceHistoryViewModelV2
            {
                Id = price.Id,
                PriceChange = price.NewPrice - price.OldPrice,
                ChangeDate = price.ChangeDate,
                ProductId = price.ProductId,
                ProductName = price.Product.Name
            }).OrderByDescending(z => z.ChangeDate).ToListAsync();
        }

    }
}
