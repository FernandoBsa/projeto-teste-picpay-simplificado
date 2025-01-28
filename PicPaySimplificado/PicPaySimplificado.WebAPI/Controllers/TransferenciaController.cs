using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Domain.Request;
using PicPaySimplificado.Service.Interfaces;

namespace PicPaySimplificado.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaService _transferenciaService;

        public TransferenciaController(ITransferenciaService transferenciaService)
        {
            _transferenciaService = transferenciaService;
        }

        [HttpPost]
        public async Task<IActionResult> PostTransfer(TransferenciaRequest request)
         {
            var result = await _transferenciaService.ExecuteAsync(request);

            if (!result.IsSuccess)
                return BadRequest(result);

            return Ok(result);
        }
    }
}
