using Microsoft.EntityFrameworkCore;
using QRCodeManagement.Application.Services;
using QRCodeManagement.Domain.Entities;
using QRCodeManagement.Infrastructure.Persistence;

namespace QRCodeManagement.Infrastructure.Services
{
    public class QRCodeService : IQRCodeService
    {
        private readonly ApplicationDbContext _context;
        private readonly IErpService _erpService;

        public QRCodeService(ApplicationDbContext context, IErpService erpService)
        {
            _context = context;
            _erpService = erpService;

        }

        public async Task<IEnumerable<QRCode>> GetAllAsync()
        {
            return await _context.QRCodes.ToListAsync();
        }

        public async Task<QRCode?> GetByIdAsync(int id)
        {
            return await _context.QRCodes.FindAsync(id);
        }

        public async Task<QRCode> GenerateCodeAsync()
        {
            string code;
            do
            {
                code = GenerateGS1Code();
            } while (await _context.QRCodes.AnyAsync(q => q.Code == code));

            var qr = new QRCode { Code = code };
            _context.QRCodes.Add(qr);
            await _context.SaveChangesAsync();

            await _erpService.NotifyNewCodeAsync(code); // ERP'ye bildir

            return qr;


        }

        public Task<bool> ValidateCodeAsync(string code)
        {
            return Task.FromResult(code.Length == 12 && code.All(char.IsDigit));
        }

        private static string GenerateGS1Code()
        {
            var random = new Random();
            return string.Concat(Enumerable.Range(0, 12).Select(_ => random.Next(10).ToString()));
        }
    }
}
