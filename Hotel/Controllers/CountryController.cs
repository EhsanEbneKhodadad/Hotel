using AutoMapper;
using Hotel.Data;
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
        public async Task<IActionResult> GetCountries([FromQuery] RequestParams requestParams)
        {
            try
            {
                var countries = await _uniteOfWork.Countries.GetByParams(requestParams);
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

        [HttpPost]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryDTO countryDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(400);
            }

            try
            {
                var country = _mapper.Map<Country>(countryDTO);
                await _uniteOfWork.Countries.Insert(country);
                await _uniteOfWork.Save();

                return Ok(country);
            }
            catch (Exception)
            {

                return StatusCode(500, "Error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateCountry(int id, [FromBody] UpdateCountryDTO countryDTO)
        {
            if(!ModelState.IsValid || id < 1)
            {
                return StatusCode(400, "Invalid Data");
            }

            var country = await _uniteOfWork.Countries.Get(i => i.Id == id);

            if(country == null)
            {
                return StatusCode(404, "Not Found");
            }

            try
            {
                _mapper.Map(countryDTO, country);
                _uniteOfWork.Countries.Update(country);
                await _uniteOfWork.Save();

                return Ok(country);
            }
            catch (Exception)
            {
                return StatusCode(500, "Server Error");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteCountry(int id)
        {
            if (id < 1)
            {
                return StatusCode(400, "Invalid Id");
            }

            var counrty = await _uniteOfWork.Countries.Get(i => i.Id == id);

            if (counrty == null)
            {
                return StatusCode(404, "Not Found");
            }

            try
            {
                await _uniteOfWork.Countries.Delete(id);
                await _uniteOfWork.Save();
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Server Error");
            }
        }
    }
}
