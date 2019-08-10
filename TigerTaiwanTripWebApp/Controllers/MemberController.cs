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
        WorldTripRepository worldTripRepository;

        public MemberController(WorldTripRepository worldTripRepository)
        {
            this.worldTripRepository = worldTripRepository;
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
            registerMember.PassWord = AESAlgorithm.EncryptAES256((string)member.member.Password);
            registerMember.Id = Guid.NewGuid();

            worldTripRepository.Create(registerMember);
            return Ok();
        }

        [HttpGet("[action]")]
        public IEnumerable<Member> ShowAllMember()
        {
            return worldTripRepository.ShowAllMember();
        }

        [HttpPost("[action]")]
        public string Login(dynamic login)
        {
            return worldTripRepository.GetLoginUser((string)login.login.userName, AESAlgorithm.EncryptAES256((string)login.login.password));
        }

        [HttpGet("[action]")]
        public Member GetCurrentUserInfo(string userName)
        {
            return worldTripRepository.GetCurrentUserInfo(userName);
        }

        [HttpPut("[action]")]
        public IActionResult Update(dynamic member)
        {
            Member updateMember = new Member();
            StringBuilder errorMessage = new StringBuilder();
            errorMessage = updateMember.Validation(member.member);
            if (errorMessage.Length != 0)
            {
                ModelState.AddModelError("errorMessage", errorMessage.ToString());
                return BadRequest(ModelState);
            }
            updateMember.BirthDay = member.member.BirthDay;
            updateMember.Email = member.member.Email;
            updateMember.MobilePhone = member.member.MobilePhone;
            updateMember.Name = member.member.Name;
            updateMember.PassWord = AESAlgorithm.EncryptAES256((string)member.member.Password);
            updateMember.Id = member.member.Id;

            worldTripRepository.Update(updateMember);
            return Ok();
        }
    }
}