using CpfValidatorAPI.Models.Requests;
using CpfValidatorAPI.Models.Responses;
using CpfValidatorAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CpfValidatorAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CpfController : ControllerBase
    {
        private readonly ICpfValidatorService _cpfValidatorService;

        public CpfController(ICpfValidatorService cpfValidatorService)
        {
            _cpfValidatorService = cpfValidatorService;
        }

        [HttpPost("validate")]
        public ActionResult<CpfResponse> ValidateCpf([FromBody] CpfRequest request)
        {
            if (!ModelState.IsValid)
                return BadRequest(new CpfResponse(false, "CPF inválido."));

            var isValid = _cpfValidatorService.IsValid(request.Cpf);
            var message = isValid ? "CPF válido." : "CPF inválido.";

            return Ok(new CpfResponse(isValid, message));
        }
    }
}
