// Services/CpfValidatorService.cs
using CpfValidatorAPI.Services.Interfaces;
using CpfValidatorAPI.Validators;

namespace CpfValidatorAPI.Services
{
    public class CpfValidatorService : ICpfValidatorService
    {
        public bool IsValid(string cpf)
        {
            return CpfValidator.IsValid(cpf);
        }
    }
}
