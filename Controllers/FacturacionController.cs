using Microsoft.AspNetCore.Mvc;
using PruebaTécnicaMVCASPADO.Models;
using PruebaTécnicaMVCASPADO.Services.Interfaces;

namespace PruebaTécnicaMVCASPADO.Controllers;

public class FacturacionController : Controller
{
    private readonly ICatalogosServiceFac<TblFacturas> _facturacionService;

    public FacturacionController(ICatalogosServiceFac<TblFacturas> facturacionService)
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
    // Buscar factura por número de factur|a
[HttpGet]
public async Task<IActionResult> BuscarFacturaPorNumeroFactura(int numeroFactura)
{
  try
  {
    TblFacturas factura = await _facturacionService.BuscarFacturaPorNumeroFactura(numeroFactura);

    if (factura != null)
    {
      return Ok(factura);
    }
    else
    {
      return NotFound();
    }
  }
  catch (Exception ex)
  {
    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
  }
}

// Buscar factura por cliente
[HttpGet]
public async Task<IActionResult> BuscarFacturaPorCliente(int idCliente)
{
  try
  {
    List<TblFacturas> facturas = await _facturacionService.BuscarFacturaPorCliente(idCliente);

    if (facturas != null && facturas.Count > 0)
    {
      return Ok(facturas);
    }
    else
    {
      return NotFound();
    }
  }
  catch (Exception ex)
  {
    return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
  }
}

}
