using Microsoft.AspNetCore.Mvc;

namespace SampleAspNetCoreWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public abstract class ApiController<TController>(ILogger<TController> logger) : ControllerBase
{
    protected ILogger<TController> Logger { get; } = logger;
}
