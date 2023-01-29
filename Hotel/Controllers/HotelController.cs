using AutoMapper;
using Hotel.IRepository;
using Hotel.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelController : ControllerBase
    {
        private readonly IUnitOfWorks _unitOfWorks;
        private readonly IMapper _mapper;


        public HotelController(IUnitOfWorks unitOfWorks, IMapper mapper)
        {
            _unitOfWorks= unitOfWorks;
            _mapper= mapper;    
        }


        [HttpGet]
        public async Task<IActionResult> GetHotels()
        {

            try
            {
                var hotels = await _unitOfWorks.HotelDatas.GetAll();
                var result = _mapper.Map<IList<HotelDataDTO>>(hotels);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Please try again later.");
                return StatusCode(500, ex.Message);
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetHotel(int id)
        {

            try
            {
                var hotels = await _unitOfWorks.HotelDatas.Get(q => q.Id == id,new List<string> { "Country" });
                var result = _mapper.Map<HotelDataDTO>(hotels);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // _logger.LogError(ex, "Please try again later.");
                return StatusCode(500, ex.Message);
            }
        }
    }
}
