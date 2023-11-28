using Microsoft.AspNetCore.Mvc;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;

namespace PruebaTécnicaMVCASPADO.Controllers;

public class FacturacionController : Controller
{
    private readonly ICatalogosService<TblFacturas> _facturacionService;

    public FacturacionController(ICatalogosService<TblFacturas> facturacionService)
    {
        _facturacionService = facturacionService;
    }

    [HttpGet]
    public IActionResult Index() => View();

    [HttpGet]
    public IActionResult BuscarFactura() => View();

    [HttpPost]
    public async Task<IActionResult> Guardar([FromBody] TblFacturas factura)
    {
        try
        {
            bool _resultado = await _facturacionService.Guardar(factura);

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
