using Microsoft.AspNetCore.Mvc;
using QRCodeManagement.Application.Services;
using QRCodeManagement.Domain.Entities;

namespace QRCodeManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CodesController : ControllerBase
    {
        private readonly IQRCodeService _service;

        public CodesController(IQRCodeService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var codes = await _service.GetAllAsync();
            return Ok(codes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var code = await _service.GetByIdAsync(id);
            return code == null ? NotFound() : Ok(code);
        }

        [HttpPost]
        public async Task<IActionResult> Create()
        {
            var newCode = await _service.GenerateCodeAsync();
            return Ok(newCode);
        }

        [HttpPost("/validate")]
        public async Task<IActionResult> Validate([FromBody] ValidateRequest request)
        {
            var isValid = await _service.ValidateCodeAsync(request.Code);
            return Ok(new { IsValid = isValid });
        }

        public class ValidateRequest
        {
            public string Code { get; set; } = string.Empty;
        }
    }
}
