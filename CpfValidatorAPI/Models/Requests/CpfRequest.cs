namespace CpfValidatorAPI.Models.Requests;
using System.ComponentModel.DataAnnotations;

public class CpfRequest
{
    [Required(ErrorMessage = "O CPF é obrigatório.")]
    [MinLength(11, ErrorMessage = "CPF deve conter no mínimo 11 dígitos.")]
    public string Cpf { get; set; } = string.Empty;
}

