using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly StoreContext _Context;

        public ProductController(StoreContext context)
        {
            _Context = context;

        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> getProducts()
        {
            var products=await _Context.Products.ToListAsync(); ///Select Query fired & it will return all the products List
            return Ok(products);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProduct(int id)
        {
            return await _Context.Products.FindAsync(id);
        }
    }
}