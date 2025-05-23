using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QRCodeManagement.Application.Services
{
    public interface IErpService
    {
        Task NotifyNewCodeAsync(string code);
    }
}
