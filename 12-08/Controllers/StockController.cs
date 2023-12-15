﻿using _12_08.Dtos;
using _12_08.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _12_08.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StockController : ControllerBase
    {
        private readonly StockRepository _stockRepository;
        public StockController()
        {
            _stockRepository = new StockRepository();
        }

        // GET: api/<StockController>
        [HttpGet]
        public IEnumerable<StockDto> Get()
        {
            return _stockRepository.GetAll();
        }

        // GET api/<StockController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StockController>
        [HttpPost("GetConditon")]
        public IEnumerable<StockDto> Post([FromBody] StockDto inpara)
        {
            return _stockRepository.GetCond(inpara);
        }
    }
}
