using QRCodeManagement.Infrastructure.Services;
using QRCodeManagement.Application.Services;
using Xunit;

namespace QRCodeManagement.Tests
{
    public class QRCodeValidationTests
    {
        private readonly IQRCodeService _service;

        public QRCodeValidationTests()
        {
            // ApplicationDbContext kullanmıyoruz çünkü test sadece validation için
            _service = new QRCodeService(null!); // DI yerine null veriyoruz çünkü bu test DB gerektirmiyor
        }

        [Theory]
        [InlineData("123456789012", true)]     // geçerli GS1
        [InlineData("123", false)]             // eksik uzunluk
        [InlineData("abcdefgh1234", false)]    // rakam dışı karakter
        [InlineData("12345678901a", false)]    // son karakter harf
        public async Task ValidateCode_Test(string input, bool expected)
        {
            var result = await _service.ValidateCodeAsync(input);
            Assert.Equal(expected, result);
        }
    }
}
