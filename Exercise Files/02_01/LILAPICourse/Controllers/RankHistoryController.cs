﻿using System;
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
    public class RankHistoryController : ControllerBase
    {
        private readonly StoreDBContext _context;

        public RankHistoryController(StoreDBContext context)
        {
            _context = context;
        }

        // GET: api/RankHistory/Product/Guid
        [HttpGet("product/{productId}")]
        public async Task<ActionResult<IEnumerable<RankHistoryViewModel>>> GetRankHistory([FromRoute]Guid productId)
        {
            return await _context.RankHistory.Where(z=>z.ProductId== productId).Select(rank=>new RankHistoryViewModel { 
             Id=rank.Id,
             Date=rank.Date,
             Rank=rank.Rank, 
             ProductId=rank.ProductId,
             ProductName=rank.Product.Name
            }).OrderByDescending(z=>z.Date).ToListAsync();
        }


    }
}
