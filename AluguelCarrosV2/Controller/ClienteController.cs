using AluguelCarrosV2.Inteface.Service;
using AluguelCarrosV2.Model;
using Microsoft.AspNetCore.Mvc;

namespace AluguelClientesV2.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ILogger<ClienteController> _logger;
        private readonly IClienteService _clienteService;

        public ClienteController(ILogger<ClienteController> logger, IClienteService clienteService)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _clienteService = clienteService ?? throw new ArgumentNullException(nameof(clienteService));
        }

        [HttpPost(template: "Create")]
        public async Task<IActionResult> CreateCliente(Cliente cliente)
        {
            var result = await _clienteService.CreateCliente(cliente);
            return Ok(result);
        }

        [HttpPost(template: "Deletar")]
        public async Task<IActionResult> DeletarCliente([FromBody] int clienteId)
        {
            if (clienteId <= 0) { return BadRequest("Id do Cliente não deve ser menor que 1"); }

            var result = await _clienteService.DeletarCliente(clienteId);
            return Ok(result);
        }

        [HttpGet("Listar")]
        public async Task<IActionResult> ListarCliente()
        {
            try
            {
                var result = await _clienteService.ListarCliente();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost(template: "Update")]
        public async Task<IActionResult> Update([FromBody] Cliente cliente)
        {
            var result = await _clienteService.UpDateCliente(cliente);
            return Ok(result);
        }
    }
}
