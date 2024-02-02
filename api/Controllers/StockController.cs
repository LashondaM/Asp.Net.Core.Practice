using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Stock;
using api.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/stock")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public StockController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            /* creates sql to go out to the DB and get the data that we need to return
            Need ToList because of deferred execution
            -- In general, if you're going to use the result of a query more than once, it's always a good 
            idea to store it via ToList() or ToArray() */
            // Select is like Map in C#
            var stocks = _context.Stock.ToList()
             .Select(s => s.ToStockDto());

            return Ok(stocks);
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            // Find is apparently better if you're just searching by the primary key
            var stock = _context.Stock.Find(id);

            if(stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToStockDto());
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateStockRequestDto stockDto)
        {
            var stockModel = stockDto.ToStockFromCreateDTO();
            _context.Stock.Add(stockModel);
            _context.SaveChanges();
            /* Once the save in the DB happens, it's going to run the GetById Call and pass in the new 
            Id that was created in this POST method and return in the form of a ToStockDto */
            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStockDto());
        }
    }
}