using AutoMapper;
using Hotel.IRepository;
using Hotel.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging;
using Serilog.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly IUnitOfWorks _uniteOfWork;
        //private readonly Logger<CountryController> _logger;
        private readonly IMapper _mapper;

        public CountryController(IUnitOfWorks uniteOfWork, IMapper mapper)
        {
            _uniteOfWork = uniteOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCountries()
        {
            try
            {
                var countries = await _uniteOfWork.Countries.GetAll();
                var results = _mapper.Map<List<CountryDTO>>(countries);
                return Ok(countries);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Please try again later.");
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetCountry(int id)
        {
            try
            {
                var countries = await _uniteOfWork.Countries.Get(q => q.Id == id, new List<string> { "Hotels" });
                var results = _mapper.Map<CountryDTO>(countries);
                return Ok(countries);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Please try again later.");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
