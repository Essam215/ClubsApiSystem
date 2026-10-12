using AutoMapper;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace ClubManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public BookingController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateBooking(CreateBookingDto dto)
        {
            var booking = _mapper.Map<Facility>(dto);
            _unitOfWork.facilityRepo.Add(booking);
            await _unitOfWork.SaveChanges();
            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> Pagination(int page, int pageSize)
        {
            var bookings = await _unitOfWork.bookingRepo.Pagination(page, pageSize);
            var result = _mapper.Map<List<GetBookingDto>>(bookings);
            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(int id)
        {
            var booking = await _unitOfWork.bookingRepo.GetById(id);
            var result = _mapper.Map<GetBookingDto>(booking);
            return Ok(result);
        }
        [HttpPut]
        public async Task<IActionResult> UpdateBooking(int id, UpdateBookingDto dto)
        {
            var booking = await _unitOfWork.bookingRepo.GetById(id);
            if (booking == null) return NotFound();
            _mapper.Map(booking, dto);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteBooking(int id)
        {
            var booking = await _unitOfWork.bookingRepo.GetById(id);
            if (booking == null) return NotFound();
            _unitOfWork.bookingRepo.Delete(booking);
            await _unitOfWork.SaveChanges();

            return NoContent(); 
        }
        [HttpGet("Report")]
        public async Task<IActionResult> Report()
        {
            var Bookings = await _unitOfWork.bookingRepo.GetAll();
            var totalNumber = Bookings.Count();
            return Ok(totalNumber);
        }
        [HttpPatch]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var booking = await _unitOfWork.bookingRepo.GetById(id);
            if (booking == null) return NotFound();

            booking.Status = "Cancelled";

            _unitOfWork.bookingRepo.Update(booking);
            await _unitOfWork.SaveChanges();
            return NoContent();
        }
    }
}
