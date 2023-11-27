using Microsoft.AspNetCore.Mvc;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;

namespace PruebaTécnicaMVCASPADO.Controllers;

public class ClienteController : Controller
{
    private readonly ICatalogosService<TblClientes> _ClienteService;

    public ClienteController(ICatalogosService<TblClientes> ClienteService)
    {
        _ClienteService = ClienteService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        List<TblClientes> _lista = await _ClienteService.Listar();
        return StatusCode(StatusCodes.Status200OK, _lista);
    }

    [HttpGet]
    public async Task<IActionResult> Selector()
    {
        var lista = await _ClienteService.Listar();
        return PartialView(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Guardar([FromBody] TblClientes producto)
    {
        bool _resultado = await _ClienteService.Guardar(producto);

        if (_resultado)
            return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
        else
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { valor = _resultado, msg = "errror" }
            );
    }

    [HttpPut]
    public async Task<IActionResult> Editar([FromBody] TblClientes producto)
    {
        bool _resultado = await _ClienteService.Editar(producto);

        if (_resultado)
            return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
        else
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { valor = _resultado, msg = "errror" }
            );
    }

    [HttpDelete]
    public async Task<IActionResult> Eliminar(int id)
    {
        bool _resultado = await _ClienteService.Eliminar(id);

        if (_resultado)
            return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
        else
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { valor = _resultado, msg = "errror" }
            );
    }
}
