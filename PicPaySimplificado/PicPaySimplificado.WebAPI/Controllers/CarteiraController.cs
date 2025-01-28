using Microsoft.AspNetCore.Mvc;
using PicPaySimplificado.Domain.Request;
using PicPaySimplificado.Service.Interfaces;

namespace PicPaySimplificado.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarteiraController : ControllerBase
    {
        private readonly ICarteiraServices _carteiraService;

        public CarteiraController(ICarteiraServices carteiraService)
        {
            _carteiraService = carteiraService;
        }

        [HttpPost]
        public async Task<IActionResult> PostCarteira(CarteiraRequest request)
        {
            var result = await _carteiraService.ExecuteAsync(request);

            if(!result.IsSuccess)
                return BadRequest(result);

            return Created();
        }
    }
}
