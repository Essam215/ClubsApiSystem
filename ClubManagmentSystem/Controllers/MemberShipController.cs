using System.Runtime.CompilerServices;
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
    public class MemberShipController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberShipController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetActiveMemberships()
        {
            var std = await _unitOfWork.memberShipRepo.GetActiveMemberShips();
            var dto = _mapper.Map<List<GetMemberShipDto>>(std);
            return Ok(dto);
        }
        [HttpPost]
        public async Task<IActionResult> CreateMemberShip(CreateMemberShipDto dto)
        {
            var memberShip = _mapper.Map<MemberShip>(dto);

            _unitOfWork.memberShipRepo.Add(memberShip);
            await _unitOfWork.SaveChanges();
            return Created();
        }
        [HttpPatch("{id}")]
        public async Task<IActionResult> RenewMemberShip(int id, PatchMemberShipDto dto)
        {
            var data = await _unitOfWork.memberShipRepo.GetMemberShipById(id, dto);
            return Ok(data);
        }
    }
}
