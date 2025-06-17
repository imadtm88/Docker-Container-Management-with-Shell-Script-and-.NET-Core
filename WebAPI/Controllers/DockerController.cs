using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Service;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/docker")]
    public class DockerController : ControllerBase
    {
        private readonly ShellService _shellService;
        private readonly string _scriptPath = "../scripts";

        public DockerController(ShellService shellService)
        {
            _shellService = shellService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> ListContainers()
        {
            var result = await _shellService.RunScriptAsync($"{_scriptPath}/list_containers.sh");
            return Ok(result);
        }

        [HttpPost("start/{id}")]
        public async Task<IActionResult> StartContainer(string id)
        {
            var result = await _shellService.RunScriptAsync($"{_scriptPath}/start_container.sh", id);
            return Ok(result);
        }

        [HttpPost("stop/{id}")]
        public async Task<IActionResult> StopContainer(string id)
        {
            var result = await _shellService.RunScriptAsync($"{_scriptPath}/stop_container.sh", id);
            return Ok(result);
        }
    }
}
