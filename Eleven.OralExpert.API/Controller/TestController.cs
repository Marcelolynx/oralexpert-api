using Microsoft.AspNetCore.Mvc;

namespace Eleven.OralExpert.API.Controller;

[ApiController]
[Route("api/[controller]")]
public class TestController : ControllerBase
{
    
    private readonly ILogger<TestController> _logger;

    public TestController(ILogger<TestController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet("throw")]
    public IActionResult ThrowError()
    {
        throw new Exception("Erro de teste!");
    }
    
    [HttpGet("test-warning")]
    public IActionResult TestWarning()
    {
        _logger.LogWarning("Este é um log de aviso gerado pelo TestController.");
        return Ok(new { Message = "Log de aviso gerado com sucesso." });
    }

    [HttpGet("test-fatal")]
    public IActionResult TestFatal()
    {
        _logger.LogCritical("Este é um log crítico gerado pelo TestController.");
        return Ok(new { Message = "Log crítico gerado com sucesso." });
    }
}
