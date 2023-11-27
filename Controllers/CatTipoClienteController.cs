using Microsoft.AspNetCore.Mvc;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;

namespace PruebaTécnicaMVCASPADO.Controllers;

public class CatTipoClienteController : Controller
{
    private readonly ICatalogosService<CatTipoCliente> _catTipoClienteService;

    public CatTipoClienteController(ICatalogosService<CatTipoCliente> catTipoClienteService)
    {
        _catTipoClienteService = catTipoClienteService;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        List<CatTipoCliente> _lista = await _catTipoClienteService.Listar();
        return StatusCode(StatusCodes.Status200OK, _lista);
    }

    public async Task<IActionResult> Selector()
    {
        var lista = await _catTipoClienteService.Listar();
        return View(lista);
    }

    [HttpPost]
    public async Task<IActionResult> Guardar([FromBody] CatTipoCliente tipoCliente)
    {
        bool _resultado = await _catTipoClienteService.Guardar(tipoCliente);

        if (_resultado)
            return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
        else
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { valor = _resultado, msg = "errror" }
            );
    }

    [HttpPut]
    public async Task<IActionResult> Editar([FromBody] CatTipoCliente tipoCliente)
    {
        bool _resultado = await _catTipoClienteService.Editar(tipoCliente);

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
        bool _resultado = await _catTipoClienteService.Eliminar(id);

        if (_resultado)
            return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
        else
            return StatusCode(
                StatusCodes.Status500InternalServerError,
                new { valor = _resultado, msg = "errror" }
            );
    }
}
