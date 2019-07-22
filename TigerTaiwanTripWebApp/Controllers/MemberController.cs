using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TigerTaiwanTripDomain;
using TigerTaiwanTripWebService;

namespace TigerTaiwanTripWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        MemberRepository memberRepository;

        public MemberController(MemberRepository memberRepository)
        {
            this.memberRepository = memberRepository;
        }

        [HttpPost("[action]")]
        public IActionResult Register(dynamic member)
        {
            Member registerMember = new Member();
            StringBuilder errorMessage = new StringBuilder();
            errorMessage = registerMember.Validation(member.member);
            if (errorMessage.Length != 0)
            {
                ModelState.AddModelError("errorMessage", errorMessage.ToString());
                return BadRequest(ModelState);
            }
            registerMember.BirthDay = member.member.BirthDay;
            registerMember.Email = member.member.Email;
            registerMember.MobilePhone = member.member.MobilePhone;
            registerMember.Name = member.member.Name;
            registerMember.PassWord = member.member.Password;
            registerMember.Id = Guid.NewGuid();

            memberRepository.Create(registerMember);
            return Ok();
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> ShowAllMember()
        {
            return memberRepository.ShowAllMember();
        }

        [HttpPost("[action]")]
        public string Login(dynamic login)
        {
            return memberRepository.GetLoginUser((string)login.login.userName, (string)login.login.password);
        }
    }
}