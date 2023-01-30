using AutoMapper;
using Hotel.Data;
using Hotel.IRepository;
using Hotel.Models;
using Hotel.Repository;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelDataDTO hotelData)
        {
            if (!ModelState.IsValid)
            {
                return StatusCode(400, "Invalid Data");
            }

            try
            {
                var hotel = _mapper.Map<HotelData>(hotelData);
                await _unitOfWorks.HotelDatas.Insert(hotel);
                await _unitOfWorks.Save();

                return StatusCode(201, "Created");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error");
            }
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateHotel(int id, [FromBody] UpdateHotelDTO hotelData)
        {
            if(!ModelState.IsValid || id < 1)
            {
                return StatusCode(400, "Invalid Data");
            }

            var hotel = await _unitOfWorks.HotelDatas.Get(i => i.Id == id);

            if(hotel == null)
            {
                return StatusCode(404, "Hotel Not Found");
            }

            try
            {
                _mapper.Map(hotelData, hotel);
                _unitOfWorks.HotelDatas.Update(hotel);
                await _unitOfWorks.Save();

                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Server Error");
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteHotel(int id)
        {
            if (id < 1)
            {
                return StatusCode(400, "Invalid Id");
            }

            var counrty = await _unitOfWorks.Countries.Get(i => i.Id == id);

            if (counrty == null)
            {
                return StatusCode(404, "Not Found");
            }

            try
            {
                await _unitOfWorks.Countries.Delete(id);
                await _unitOfWorks.Save();
                return NoContent();
            }
            catch (Exception)
            {

                return StatusCode(500, "Server Error");
            }
        }
    }
}
