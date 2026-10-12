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
    public class PaymentController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PaymentController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreatePayment(CreatePaymentDto dto)
        {
            var payment = _mapper.Map<Payment>(dto);
            _unitOfWork.paymentRepo.Add(payment);
            await _unitOfWork.SaveChanges();

            return Created();
        }
        [HttpGet]
        public async Task<IActionResult> Statistics()
        {
            var result = await _unitOfWork.paymentRepo.GetAll();
            var MaxAmount = result.Max(s => s.Amount);

            return Ok(MaxAmount);
        }
    }
}
