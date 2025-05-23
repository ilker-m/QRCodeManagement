using QRCodeManagement.Domain.Entities;

namespace QRCodeManagement.Application.Services
{
    public interface IQRCodeService
    {
        Task<IEnumerable<QRCode>> GetAllAsync();
        Task<QRCode?> GetByIdAsync(int id);
        Task<QRCode> GenerateCodeAsync();
        Task<bool> ValidateCodeAsync(string code);
    }
}
