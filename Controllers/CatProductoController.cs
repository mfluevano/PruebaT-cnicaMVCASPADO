/* controlador C# para un CatProducto (Categoría de producto)
en una aplicación ASP.NET Core MVC. utilizando Ado  sin entity framework
 */
using Microsoft.AspNetCore.Mvc;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;

namespace PruebaTécnicaMVCASPADO.Controllers;

public class CatProductoController : Controller
{
    private readonly ICatalogosService<CatProducto> _catPoductoService;

    public CatProductoController(ICatalogosService<CatProducto> catPoductoService)
    {
        _catPoductoService = catPoductoService;
    }

    [HttpGet]
    public IActionResult Index() => View();

    
    [HttpGet]
    public async Task<IActionResult> Listar()
    {
        try
        {
            List<CatProducto> _lista = await _catPoductoService.Listar();
            return StatusCode(StatusCodes.Status200OK, _lista);
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    public async Task<IActionResult> Selector()
    {
        var lista = await _catPoductoService.Listar();
        return PartialView(lista);
    }

    
    [HttpPost]
    public async Task<IActionResult> Guardar([FromBody] CatProducto producto)
    {
        try
        {
            bool _resultado = await _catPoductoService.Guardar(producto);

            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            }
            else
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { valor = _resultado, msg = "error" }
                );
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public async Task<IActionResult> Editar([FromBody] CatProducto producto)
    {
        try
        {
            bool _resultado = await _catPoductoService.Editar(producto);

            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            }
            else
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { valor = _resultado, msg = "error" }
                );
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    public async Task<IActionResult> Eliminar(int id)
    {
        try
        {
            bool _resultado = await _catPoductoService.Eliminar(id);

            if (_resultado)
            {
                return StatusCode(StatusCodes.Status200OK, new { valor = _resultado, msg = "ok" });
            }
            else
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new { valor = _resultado, msg = "error" }
                );
            }
        }
        catch (Exception ex)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
        }
    }
}
