using AluguelCarrosV2.Inteface.Service;
using AluguelCarrosV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace AluguelCarrosV2.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ILogger<CarroController> _logger;
        private readonly ICarroService _carroService;

        public CarroController(ILogger<CarroController> logger, ICarroService carroService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _carroService = carroService ?? throw new ArgumentNullException(nameof(carroService));
        }

        [HttpPost(template: "Create")]
        public async Task<IActionResult> CreateCarro(Carro carro)
        {
            var result = await _carroService.CreateCarro(carro);
            return Ok(result);
        }

        [HttpPost(template: "AlugarCarro")]
        public async Task<IActionResult> AlugarCarro([FromBody] string nomeCarro, string nomeCliente)
        {
            var result = await _carroService.AlugarCarro(nomeCarro, nomeCliente);
            return Ok(result);
        }


        [HttpPost(template: "Deletar")]
        public async Task<IActionResult> DeletarCarro([FromBody] int carroId)
        {
            if (carroId <= 0) { return BadRequest("Id do carro não deve ser menor que 1"); }

            var result = await _carroService.DeletarCarro(carroId);
            return Ok(result);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarCarro()
        {
            try
            {
                var result = await _carroService.ListarCarro();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(template: "Update")]
        public async Task<IActionResult> Update([FromBody] Carro carro)
        {
            var result = await _carroService.UpDateCarro(carro);
            return Ok(result);
        }
    }
    }