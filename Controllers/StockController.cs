using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockApp.DTOs.Stock;
using StockApp.Helper;
using StockApp.Interfaces;
using StockApp.Mapper;

namespace StockApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly IStockRepository _stockRepository;

        public StockController(IStockRepository stockRepository) 
        {
            _stockRepository = stockRepository;
        }

        [HttpGet("{id:int}")]       
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stock = await _stockRepository.GetByIdAsync(id);

            if (stock == null) { return NotFound(); }

            return Ok(stock.ToStock());
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateStockRequestDto stockDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // a mapper is like an extension method which we can use to transform our data into what we want alongside the dto

            var stockModel = stockDto.ToStockFromCreateDTO();
            
            await _stockRepository.CreateAsync(stockModel);

            return CreatedAtAction(nameof(GetById), new {id = stockModel.Id}, stockModel.ToStock());
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update([FromRoute] int id, UpdateStockRequestDto updateDto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            // check if stock firet exist, before updating
            var stockModel = await _stockRepository.UpdateAsync(id, updateDto);

            // check iif stockmodel is null
            if (stockModel == null)
            {
                return NotFound();
            }
            return Ok(stockModel.ToStock());
        }

        [HttpGet]
        [Route("get-all")]
        public async Task<IActionResult> GetAll([FromQuery] QueryObject query)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stocks = await _stockRepository.GetAllAsync(query);
            //var stockDto = stocks.Select(x => x.ToStock()).ToList();

            return Ok(stocks);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var stocks = await _stockRepository.DeleteAsync(id);
            // check if stocks is null
            if (stocks == null)
            {
                return NotFound();
            }
            return NoContent();

        }
    }
}
