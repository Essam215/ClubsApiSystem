using AutoMapper;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClubManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilityController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FacilityController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> SoryByCapacity()
        {
            var facilities = await _unitOfWork.facilityRepo.OrderByCapacity();
            var dto = _mapper.Map<List<GetFacilityDto>>(facilities);
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateFacility(CreateFacilityDto dto)
        {
            var facility = _mapper.Map<Facility>(dto);
             _unitOfWork.facilityRepo.Add(facility);
            await _unitOfWork.SaveChanges();
            return Ok(facility);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteFacility(int id)
        {
            var fac = await _unitOfWork.facilityRepo.GetById(id);
            if (fac == null || fac.Bookings.Count() > 0) return BadRequest("Either the facility has a booking record or it is null");
            _unitOfWork.facilityRepo.Delete(fac);
            return NoContent();
        }
    }
}
