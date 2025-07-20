using Xunit;
using CpfValidatorAPI.Validators;

namespace CpfValidatorAPI.Tests
{
    public class CpfValidatorTests
    {
        [Theory(DisplayName = "Validação de CPF deve retornar o resultado esperado")]
        [InlineData("529.982.247-25", true)]
        [InlineData("123.456.789-09", true)]
        [InlineData("000.000.000-00", false)]
        [InlineData("111.111.111-11", false)]
        [InlineData("52998224725", true)]
        [InlineData("529.982.247-2X", false)]
        [InlineData("", false)]              // String vazia
        [InlineData(null, false)]            // Valor nulo
        [InlineData("123", false)]
        [InlineData("     ", false)]         // Espaços em branco
        [InlineData("111.444.777-00", false)]
        [InlineData("ABCDEFGHIJK", false)]
        public void Cpf_Deve_Validar_Corretamente(string cpf, bool esperado)
        {
            // Act
            var resultado = CpfValidator.IsValid(cpf);

            // Formata visualmente o valor do CPF para debug
            var visivel = cpf == null ? "null"
                         : string.IsNullOrWhiteSpace(cpf) ? "(em branco)"
                         : cpf;

            // Assert com mensagem clara para facilitar depuração em caso de falha
            Assert.True(resultado == esperado, $"""
                        Erro ao validar CPF:'{visivel}'                        
                        - Esperado: {esperado}
                        - Obtido: {resultado}
                        """);

        }
    }
}
