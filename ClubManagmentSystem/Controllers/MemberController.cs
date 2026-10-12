using AutoMapper;
using AutoMapper.Execution;
using ClubManagmentSystem.Data;
using ClubManagmentSystem.DTO_s;
using ClubManagmentSystem.Models;
using ClubManagmentSystem.UOW;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Member = ClubManagmentSystem.Models.Member;

namespace ClubManagmentSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MemberController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> CreateMember(CreateMemberDto dto)
        {
            var member = _mapper.Map<Member>(dto);

            
            _unitOfWork.memberRepo.Add(member);
            await _unitOfWork.SaveChanges();    

            return Created();
        }
        [HttpPut]
        public async Task<IActionResult> UpdateMember(int id, UpdateMemberDto dto)
        {
            var std = await _unitOfWork.memberRepo.GetById(id);
            if (std == null) return NotFound();

            _mapper.Map(dto, std);

            await _unitOfWork.SaveChanges();
            return NoContent();
        }
        [HttpGet("Search")]
        public async Task<IActionResult> Search(string name)
        {
            var products = await _unitOfWork.memberRepo.Search(name);
            var productDtos = _mapper.Map<List<GetMemberDto>>(products);
            return Ok(productDtos);
        }
        [HttpGet("Pagination")]
        public async Task<IActionResult> Pagination(int page, int pageSize)
        {
            var std = await _unitOfWork.memberRepo.Pagination(page, pageSize);
            var dto = _mapper.Map<List<GetMemberDto>>(std);
            return Ok(dto);
        }
    }
}
